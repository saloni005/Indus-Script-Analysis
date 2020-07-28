Text Extraction from seals, painting, coins, rocks or any anctient scriptures using the Convolution Neural Network

Input: Ancient Scripture images after intensity, size and color normalization
Output: Digital printed text like OCR
Algorithm used: CNN

Training is divided into two phases:
->In the training NN Phase I, we used convolutions of 5 x 5 for all the input images and
feed it to the NN. Architecture of the NN comprises of 75 input neurons, 100 hidden
neurons and 1 output neurons along with the learning rate of 0.01.

->In order to remove noise from the result obtained from the training NN Phase I, we used
another NN configuration with 25 input neurons, 100 hidden neurons and 1 output
neurons in it along with learning rate of 0.01. This step for image restoration will bypass several image processing techniques for noise removal like fuzzy filter, salt-pepper algorithm etc.


