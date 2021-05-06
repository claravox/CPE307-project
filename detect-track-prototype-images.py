#!/usr/bin/python
'''
    Author: Guido Diepen <gdiepen@deloitte.nl>
'''

#Import the OpenCV and dlib libraries
import cv2
import sys
import numpy as np
import time


# https://raw.githubusercontent.com/opencv/opencv/master/samples/dnn/face_detector/deploy.prototxt
#prototxt_path = "weights/deploy.prototxt.txt"
# https://raw.githubusercontent.com/opencv/opencv_3rdparty/dnn_samples_face_detector_20180205_fp16/res10_300x300_ssd_iter_140000_fp16.caffemodel 
#model_path = "weights/res10_300x300_ssd_iter_140000_fp16.caffemodel"


#Initialize a face cascade using the frontal face haar cascade provided with
#the OpenCV library
faceCascade = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')



def detectAndTrackLargestFace():
    # Image to put over face
    flower = cv2.imread('flower.png', cv2.IMREAD_UNCHANGED)

    #Open the first webcame device
    capture = cv2.VideoCapture(0)
    time.sleep(0.5)

    #Create the tracker we will use
    tracker = cv2.TrackerKCF_create()

    #The variable we use to keep track of the fact whether we are tracking a face right now
    #currently using KCF tracker
    trackingFace = 0

    #The color of the rectangle we draw around the face
    rectangleColor = (0,165,255)

    frame_num = 0
    frame_reset_thresh = 120

    try:
        while True:
            #Retrieve the latest image from the webcam
            ok, frame = capture.read()
            if not ok:
                print('Cannot read video file')
                sys.exit()


            #Check if a key was pressed and if it was Q, then destroy all
            #opencv windows and exit the application
            pressedKey = cv2.waitKey(2)
            if pressedKey == ord('Q'):
                cv2.destroyAllWindows()
                exit(0)

            # get width and height of the image
            h, w = frame.shape[:2]
            kernel_width = (w // 7) | 1
            kernel_height = (h // 7) | 1


            #If we are not tracking a face, then try to detect one
            if not trackingFace or frame_num > frame_reset_thresh:
                
                #For the face detection, we need to make use of a gray
                #colored image so we will convert the baseImage to a
                #gray-based image
                gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
                #Now use the haar cascade detector to find all faces
                #in the image
                faces = faceCascade.detectMultiScale(gray, 1.3, 5)


                #For now, we are only interested in the 'largest'
                #face, and we determine this based on the largest
                #area of the found rectangle. First initialize the
                #required variables to 0
                maxArea = 0
                x = 0
                y = 0
                w = 0
                h = 0


                #Loop over all faces and check if the area for this
                #face is the largest so far
                #We need to convert it to int here because of the
                #requirement of the dlib tracker. If we omit the cast to
                #int here, you will get cast errors since the detector
                #returns numpy.int32 and the tracker requires an int
                for (_x,_y,_w,_h) in faces:
                    if  _w*_h > maxArea:
                        x = int(_x)
                        y = int(_y)
                        w = int(_w)
                        h = int(_h)
                        maxArea = w*h

                #If one or more faces are found, initialize the tracker
                #on the largest face in the picture
                if maxArea > 0 :
                    tracker = cv2.TrackerKCF_create()
                    ok = tracker.init(frame, (x, y, w, h))
                    #Set the indicator variable such that we know the
                    #tracker is tracking a region in the image
                    trackingFace = 1


            #Check if the tracker is actively tracking a region in the image
            if trackingFace:
                #Update the tracker and request information about the
                #quality of the tracking update
                ok, bbox = tracker.update(frame)

                # If the tracking quality is good enough, determine the
                # updated position of the tracked region and blur the face!
                if ok:
                    # Tracking success
                    x, y, w, h = bbox
                    start_x, start_y, end_x, end_y = x, y, x + w, y + h
                    # get the face image
                    face = frame[start_y: end_y, start_x: end_x]
                    # apply gaussian blur to this face
                    #face = cv2.GaussianBlur(face, (kernel_width, kernel_height), 0)
                    # put the blurred face into the original image
                    #frame[start_y: end_y, start_x: end_x] = face

                    #cv2.rectangle(frame, (x, y), (x + w, y + h), (255,0,0), 2)

                    #Finally, we want to show the images on the screen
                    flower_new = cv2.resize(flower, (w, h), interpolation = cv2.INTER_AREA)
                    overlay_transparent(frame, flower_new, x, y)

                else:
                    #If the quality of the tracking update is not
                    #sufficient (e.g. the tracked region moved out of the
                    #screen) we stop the tracking of the face and in the
                    # next loop we will find the largest face in the image
                    # again
                    trackingFace = 0


            cv2.imshow("Frame", frame)

            frame_num += 1



    #To ensure we can also deal with the user pressing Ctrl-C in the console
    #we have to check for the KeyboardInterrupt exception and destroy
    #all opencv windows and exit the application
    except KeyboardInterrupt as e:
        cv2.destroyAllWindows()
        exit(0)


# https://stackoverflow.com/questions/40895785/using-opencv-to-overlay-transparent-image-onto-another-image
def overlay_transparent(background, overlay, x, y):

    background_width = background.shape[1]
    background_height = background.shape[0]

    if x >= background_width or y >= background_height:
        return background

    h, w = overlay.shape[0], overlay.shape[1]

    if x + w > background_width:
        w = background_width - x
        overlay = overlay[:, :w]

    if y + h > background_height:
        h = background_height - y
        overlay = overlay[:h]

    if overlay.shape[2] < 4:
        overlay = np.concatenate(
            [
                overlay,
                np.ones((overlay.shape[0], overlay.shape[1], 1), dtype = overlay.dtype) * 255
            ],
            axis = 2,
        )

    overlay_image = overlay[..., :3]
    mask = overlay[..., 3:] / 255.0

    background[y:y+h, x:x+w] = (1.0 - mask) * background[y:y+h, x:x+w] + mask * overlay_image

    return background


if __name__ == '__main__':
    detectAndTrackLargestFace()
