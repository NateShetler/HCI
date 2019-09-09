cmake_minimum_required(VERSION 3.0)   
project(pa1_part3)              
set(CMAKE_CXX_STANDARD 11)
SET(CMAKE_CXX_FLAGS ${CMAKE_CXX_FLAGS} "-std=c++11 -pthread")           

set(SOURCE_FILES pa1_part3.cpp)           
add_executable(pa1_part3 ${SOURCE_FILES}) 