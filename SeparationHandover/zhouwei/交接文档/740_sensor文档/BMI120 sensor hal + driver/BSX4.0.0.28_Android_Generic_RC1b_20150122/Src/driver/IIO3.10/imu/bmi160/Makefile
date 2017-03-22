#
#Makefile for BMI160 IIO Driver
#
obj-y   += bmi160_i2c.o bmi160_core.o bmi160_api.o 
obj-y   += bmi160_ring.o

CFLAGS_bmi160_core.o +=  -Idrivers/staging
CFLAGS_bmi160_api.o +=  -Idrivers/staging
CFLAGS_bmi160_i2c.o +=  -Idrivers/staging
CFLAGS_bmi160_ring.o +=  -Idrivers/staging
CFLAGS_bmi160_trigger.o += -Idrivers/staging
EXTRA_CFLAGS += -DBMI_USE_BASIC_I2C_FUNC
