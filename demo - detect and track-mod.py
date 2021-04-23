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
prototxt_path = "weights/deploy.prototxt.txt"
# https://raw.githubusercontent.com/opencv/opencv_3rdparty/dnn_samples_face_detector_20180205_fp16/res10_300x300_ssd_iter_140000_fp16.caffemodel 
model_path = "weights/res10_300x300_ssd_iter_140000_fp16.caffemodel"


#Initialize a face cascade using the frontal face haar cascade provided with
#the OpenCV library
#faceCascade = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')

#The deisred output width and height
OUTPUT_SIZE_WIDTH = 775
OUTPUT_SIZE_HEIGHT = 600

# load Caffe model
model = cv2.dnn.readNetFromCaffe(prototxt_path, model_path)

def detectAndTrackLargestFace():
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
            if not trackingFace:
                
                # preprocess the image: resize and performs mean subtraction
                # Could replace 177 with 117, apparently there's some controversy on this
                blob = cv2.dnn.blobFromImage(frame, 1.0, (300, 300), (104.0, 177.0, 123.0))
                # set the image into the input of the neural network
                model.setInput(blob)
                # perform inference and get the result
                output = np.squeeze(model.forward())


                for i in range(0, output.shape[0]):
                    confidence = output[i, 2]
                    # get the confidence
                    # if confidence is above 40%, then blur the bounding box (face)
                    if confidence > 0.4:
                        # get the surrounding box cordinates and upscale them to original image
                        box = output[i, 3:7] * np.array([w, h, w, h])
                        # convert to integers
                        start_x, start_y, end_x, end_y = box.astype(int)
                        # get the face image
                        face = frame[start_y: end_y, start_x: end_x]
                        # apply gaussian blur to this face
                        face = cv2.GaussianBlur(face, (kernel_width, kernel_height), 0)
                        # put the blurred face into the original image
                        frame[start_y: end_y, start_x: end_x] = face

                        # Set the indicator variable such that we know the
                        # tracker is tracking a region in the image
                        trackingFace = 1

                        tracker = cv2.TrackerKCF_create()
                        ok = tracker.init(frame, (start_x, start_y, end_x - start_x, end_y - start_y))



            #Check if the tracker is actively tracking a region in the image
            elif trackingFace:
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
                    face = cv2.GaussianBlur(face, (kernel_width, kernel_height), 0)
                    # put the blurred face into the original image
                    frame[start_y: end_y, start_x: end_x] = face

                    #cv2.rectangle(frame, (x, y), (x + w, y + h), (255,0,0), 2)

                else:
                    #If the quality of the tracking update is not
                    #sufficient (e.g. the tracked region moved out of the
                    #screen) we stop the tracking of the face and in the
                    # next loop we will find the largest face in the image
                    # again
                    trackingFace = 0



            #Finally, we want to show the images on the screen
            cv2.imshow("Frame", frame)



    #To ensure we can also deal with the user pressing Ctrl-C in the console
    #we have to check for the KeyboardInterrupt exception and destroy
    #all opencv windows and exit the application
    except KeyboardInterrupt as e:
        cv2.destroyAllWindows()
        exit(0)


if __name__ == '__main__':
    detectAndTrackLargestFace()
