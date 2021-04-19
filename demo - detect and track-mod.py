#!/usr/bin/python
'''
    Author: Guido Diepen <gdiepen@deloitte.nl>
'''

#Import the OpenCV and dlib libraries
import cv2
import sys
import time


#Initialize a face cascade using the frontal face haar cascade provided with
#the OpenCV library
faceCascade = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')

#The deisred output width and height
OUTPUT_SIZE_WIDTH = 775
OUTPUT_SIZE_HEIGHT = 600

def detectAndTrackLargestFace():
    #Open the first webcame device
    capture = cv2.VideoCapture(0)
    time.sleep(0.5)

    #Create the tracker we will use
    tracker = cv2.TrackerKCF_create()

    #The variable we use to keep track of the fact whether we are
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


            #If we are not tracking a face, then try to detect one
            if not trackingFace:

                #For the face detection, we need to make use of a gray
                #colored image so we will convert the baseImage to a
                #gray-based image
                gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
                #Now use the haar cascade detector to find all faces
                #in the image
                faces = faceCascade.detectMultiScale(gray, 1.3, 5)

                #In the console we can show that only now we are
                #using the detector for a face
                #print("Using the cascade detector to detect face")


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

                    #Initialize the tracker
                    #tracker.start_track(baseImage,
                    #                    dlib.rectangle( x-10,
                    #                                    y-20,
                    #                                    x+w+10,
                    #                                    y+h+20))
                    # Initialize tracker with first frame and bounding box
                    # Define an initial bounding box
                    bbox = (x-10, y-20, x+w+10, y+h+20)
                    ok = tracker.init(frame, bbox)

                    #Set the indicator variable such that we know the
                    #tracker is tracking a region in the image
                    trackingFace = 1

            #Check if the tracker is actively tracking a region in the image
            if trackingFace:

                #Update the tracker and request information about the
                #quality of the tracking update
                ok, bbox = tracker.update(frame)

                #If the tracking quality is good enough, determine the
                #updated position of the tracked region and draw the
                #rectangle
                if ok:
                    # Tracking success
                    p1 = (int(bbox[0]), int(bbox[1]))
                    p2 = (int(bbox[0] + bbox[2]), int(bbox[1] + bbox[3]))
                    cv2.rectangle(frame, p1, p2, (255,0,0), 2, 1)

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
