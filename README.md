# HSoD2TextureMerge
A tool to merge RGB image with another Alpha channel image into one RGBA transprant image.

## Background
 Most Unity3D based mobile game using ETC1 technique to compress resources on Andriod which does not support Alpha channel.
  
 An image only store the Alpha channel was separated from original. This tools is for merging them back.

## Feature
 * Merge all images inside the selected parent folder
 * Preview result

## ToDo
 * Multi-Thread support
 * Many RGB images sharing the same stucture that using the same Alpha channel image
 * Autosize Alpha images to fit RGB images
 * <del>Better algorithm. ...........</del>  Now using pointer instead of GetPixel() and SetPixel()
 * Unity bundle support...................
 
## Notice
 The tool currently using Single-Thread to run, which means it would unable to response after start processing images. QAQ
