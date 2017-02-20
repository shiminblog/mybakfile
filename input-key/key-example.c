/**
*@file Aw9523_drv.c
*@author wuguang
*@date 2014-12-9
*@keypad dirver
*@H02 keypad devices dirver.
*/

#include <linux/module.h>
#include <linux/init.h>
#include <linux/interrupt.h>
#include <linux/irq.h>
#include <linux/workqueue.h>
#include <linux/errno.h>
#include <linux/pm.h>
#include <linux/platform_device.h>
#include <linux/input.h>
#include <linux/i2c.h>
#include <linux/gpio.h>
#include <linux/slab.h>
#include <linux/wait.h>
#include <linux/time.h>
#include <linux/delay.h>
#include <linux/of_gpio.h>
#include <linux/pinctrl/consumer.h>
#include <linux/regulator/consumer.h>

#include <linux/input/aw9523_cfg.h>
//<!--wuguang add for debug--!>
#include <linux/leds.h>
#undef pr_debug
#define pr_debug(fmt, ...)\
			printk(KERN_ERR pr_fmt(fmt), ##__VA_ARGS__)
// end -->
//#define AW9523_DEBUG

#define P0_KROW_MASK 0xfc
#define P1_KCOL_MASK 0xf4//0xf0

#define KROW_P0_0 1
#define KROW_P0_1 2
#define KROW_P0_2 3
#define KROW_P0_3 4
#define KROW_P0_4 5
#define KROW_P0_5 6
#define KROW_P0_6 7
#define KROW_P0_7 8

#define KROW_P1_0 1
#define KROW_P1_1 2
#define KROW_P1_2 3
#define KROW_P1_3 4
#define KROW_P1_4 5
#define KROW_P1_5 6
#define KROW_P1_6 7
#define KROW_P1_7 8

//reg list
#define P0_INPUT	0x00
#define P1_INPUT 	0x01
#define P0_OUTPUT 	0x02
#define P1_OUTPUT 	0x03
#define P0_CONFIG	0x04
#define p1_CONFIG 	0x05
#define P0_INT		0x06
#define P1_INT		0x07
#define ID_REG		0x10
#define CTL_REG		0x11
#define P0_LED_MODE	0x12
#define P1_LED_MODE	0x13
#define P1_0_DIM0   0x20
#define P1_1_DIM0   0x21
#define P1_2_DIM0   0x22
#define P1_3_DIM0   0x23
#define P0_0_DIM0   0x24
#define P0_1_DIM0   0x25
#define P0_2_DIM0   0x26
#define P0_3_DIM0   0x27
#define P0_4_DIM0   0x28
#define P0_5_DIM0   0x29
#define P0_6_DIM0   0x2A
#define P0_7_DIM0   0x2B
#define P1_4_DIM0   0x2C
#define P1_5_DIM0   0x2D
#define P1_6_DIM0   0x2E
#define P1_7_DIM0   0x2F
#define SW_RSTN		0x7F

enum {
         COLOR_R,
          COLOR_G, 
	  COLOR_B, 
	  COLOR_RED,
          COLOR_GREEN, 
	  COLOR_BLUE, 
	 NO_LEDS};
	   
#define MAX_RGBLED_VALUE 255

KEY_STATE key_map[]={
#if 0
	{"2"	,KEY_A,		0,	KROW_P0_2,	KROW_P1_4},
	{"1"	,KEY_B,		0,	KROW_P0_2,	KROW_P1_5},
	{"3"	,KEY_C,		0,	KROW_P0_2,	KROW_P1_6},
	{"xxx"	,KEY_D,		0,	KROW_P0_2,	KROW_P1_7},
	{"5"	,KEY_E,		0,	KROW_P0_3,	KROW_P1_4},
	{"4"	,KEY_F,		0,	KROW_P0_3,	KROW_P1_5},
	{"6"	,KEY_G,		0,	KROW_P0_3,	KROW_P1_6},
	{"RIGHT",KEY_H,		0,	KROW_P0_3,	KROW_P1_7},
	{"F"	,KEY_I,		0,	KROW_P0_4,	KROW_P1_4},
	{"LEFT"	,KEY_J,		0,	KROW_P0_4,	KROW_P1_5},
	{"menu"	,KEY_K,		0,	KROW_P0_4,	KROW_P1_6},
	{"OK"	,KEY_L,		0,	KROW_P0_4,	KROW_P1_7},
	{"8"	,KEY_M,		0,	KROW_P0_5,	KROW_P1_4},
	{"7"	,KEY_N,		0,	KROW_P0_5,	KROW_P1_5},
	{"9"	,KEY_O,		0,	KROW_P0_5,	KROW_P1_6},
	{"mode"	,KEY_P,		0,	KROW_P0_5,	KROW_P1_7},
	{"0"	,KEY_Q,		0,	KROW_P0_6,	KROW_P1_4},
	{"*"	,KEY_R,		0,	KROW_P0_6,	KROW_P1_5},
	{"#"	,KEY_S,		0,	KROW_P0_6,	KROW_P1_6},
	{"UP"	,KEY_T,		0,	KROW_P0_6,	KROW_P1_7},
	{"DOWN"	,KEY_U,		0,	KROW_P0_7,	KROW_P1_4},
	#else
#if 1
	{"2"	,	KEY_2,		0,	KROW_P0_6,	KROW_P1_4},
	{"1"	,	KEY_1,		0,	KROW_P0_7,	KROW_P1_4},
	{"3"	,	KEY_3,		0,	KROW_P0_5,	KROW_P1_4},
	{"BACK"	,KEY_BACK,	0,	KROW_P0_2,	KROW_P1_4},
	{"5"	,	KEY_5,		0,	KROW_P0_3,	KROW_P1_5},
	{"4"	,	KEY_4,		0,	KROW_P0_4,	KROW_P1_5},
	{"6"	,	KEY_6,		0,	KROW_P0_2,	KROW_P1_5},
	{"RIGHT",  KEY_RIGHT,		0,	KROW_P0_3,	KROW_P1_2},
	{"DEL"	,KEY_BACKSPACE,		0,	KROW_P0_7,	KROW_P1_2},///
	{"LEFT"	,KEY_LEFT,		0,	KROW_P0_5,	KROW_P1_2},
	{"menu"	,KEY_MENU,		0,	KROW_P0_3,	KROW_P1_4},
	{"OK"	,KEY_ENTER,		0,	KROW_P0_2,	KROW_P1_2},
	{"8"	,	KEY_8,		0,	KROW_P0_6,	KROW_P1_5},
	{"7"	,	KEY_7,		0,	KROW_P0_2,	KROW_P1_6},
	{"9"	,	KEY_9,		0,	KROW_P0_5,	KROW_P1_5},
	{"scan"	,KEY_SCALE,		0,	KROW_P0_4,	KROW_P1_4},///scan
	{"0"	,	KEY_0,		0,	KROW_P0_4,	KROW_P1_6},
	{"*"	,	KEY_SWITCHVIDEOMODE,		0,	KROW_P0_3,	KROW_P1_6},
	{"#"	,	KEY_KBDILLUMTOGGLE,		0,	KROW_P0_5,	KROW_P1_6},
	{"UP"	,KEY_UP,		0,	KROW_P0_6,	KROW_P1_2},
	{"DOWN"	,KEY_DOWN,		0,	KROW_P0_4,	KROW_P1_2},
	
	{"F1"	,KEY_F1,		0,	KROW_P0_6,	KROW_P1_6},
	{"F2"	,KEY_F2,		0,	KROW_P0_4,	KROW_P1_7},
	{"F3"	,KEY_F3,		0,	KROW_P0_3,	KROW_P1_7},
	{"F4"	,KEY_F4,		0,	KROW_P0_2,	KROW_P1_7},
	{"F5"	,KEY_F5,		0,	KROW_P0_6,	KROW_P1_7},
	{"F6"	,KEY_F6,		0,	KROW_P0_5,	KROW_P1_7},

#else
	{"2"	,	KEY_A,		0,	KROW_P0_6,	KROW_P1_4},
	{"1"	,	KEY_B,		0,	KROW_P0_7,	KROW_P1_4},
	{"3"	,	KEY_C,		0,	KROW_P0_5,	KROW_P1_4},
	{"BACK"	,KEY_D,	0,	KROW_P0_2,	KROW_P1_4},
	{"5"	,	KEY_E,		0,	KROW_P0_3,	KROW_P1_5},
	{"4"	,	KEY_F,		0,	KROW_P0_4,	KROW_P1_5},
	{"6"	,	KEY_G,		0,	KROW_P0_2,	KROW_P1_5},
	{"RIGHT",  KEY_RIGHT,		0,	KROW_P0_3,	KROW_P1_2},
	{"DEL"	,KEY_DELETE,		0,	KROW_P0_7,	KROW_P1_2},///
	{"LEFT"	,KEY_LEFT,		0,	KROW_P0_5,	KROW_P1_2},
	{"menu"	,KEY_MENU,		0,	KROW_P0_3,	KROW_P1_4},
	{"OK"	,KEY_OK,		0,	KROW_P0_2,	KROW_P1_2},
	{"8"	,	KEY_M,		0,	KROW_P0_6,	KROW_P1_5},
	{"7"	,	KEY_N,		0,	KROW_P0_2,	KROW_P1_6},
	{"9"	,	KEY_O,		0,	KROW_P0_5,	KROW_P1_5},
	{"scan"	,KEY_P,		0,	KROW_P0_4,	KROW_P1_4},///scan
	{"0"	,	KEY_Q,		0,	KROW_P0_4,	KROW_P1_6},
	{"*"	,	KEY_R,		0,	KROW_P0_3,	KROW_P1_6},
	{"#"	,	KEY_S,		0,	KROW_P0_5,	KROW_P1_6},
	{"UP"	,KEY_T,		0,	KROW_P0_6,	KROW_P1_2},
	{"DOWN"	,KEY_U,		0,	KROW_P0_4,	KROW_P1_2},
	
	{"F1"	,KEY_V,		0,	KROW_P0_6,	KROW_P1_6},
	{"F2"	,KEY_W,		0,	KROW_P0_4,	KROW_P1_7},
	{"F3"	,KEY_X,		0,	KROW_P0_3,	KROW_P1_7},
	{"F4"	,KEY_Y,		0,	KROW_P0_2,	KROW_P1_7},
	{"F5"	,KEY_Z,		0,	KROW_P0_6,	KROW_P1_7},
	{"F6"	,KEY_Z,		0,	KROW_P0_5,	KROW_P1_7},
#endif
	#endif
};
struct aw9523_kpad_platform_data *g_aw9523_data;
//EXPORT_SYMBOL_GPL(aw9523_led_store);


static int __aw9523_read_reg(struct i2c_client *client, int reg, unsigned char *val)
{
	int ret;

	ret = i2c_smbus_read_byte_data(client, reg);
	if (ret < 0) {
		dev_err(&client->dev, "i2c read fail: can't read from %02x: %d\n", reg, ret);
		return ret;
	} else {
		*val = ret;
	}
	return 0;
}

static int __aw9523_write_reg(struct i2c_client *client, int reg, int val)
{
	int ret;

	ret = i2c_smbus_write_byte_data(client, reg, val);
	if (ret < 0) {
		dev_err(&client->dev, "i2c write fail: can't write %02x to %02x: %d\n",
			val, reg, ret);
		return ret;
	}
	return 0;
}

static int aw9523_read_reg(struct i2c_client *client, int reg,
						unsigned char *val)
{
	int rc;
	struct aw9523_kpad_platform_data *pdata;

	pdata = i2c_get_clientdata(client);
	mutex_lock(&pdata->read_write_lock);
	rc = __aw9523_read_reg(client, reg, val);
	mutex_unlock(&pdata->read_write_lock);

	return rc;
}

static int aw9523_write_reg(struct i2c_client *client, int reg,
						unsigned char val)
{
	int rc;
	struct aw9523_kpad_platform_data *pdata;

	pdata = i2c_get_clientdata(client);
	mutex_lock(&pdata->read_write_lock);
	rc = __aw9523_write_reg(client, reg, val);
	mutex_unlock(&pdata->read_write_lock);

	return rc;
}

void aw9523_p0_int_restore(struct i2c_client *client)
{
    aw9523_write_reg(client, P0_INT, 0x00);
}

void aw9523_p1_int_restore(struct i2c_client *client, unsigned char val)
{
    aw9523_write_reg(client, P1_INT, val);
}

void aw9523_p0_int_disable(struct i2c_client *client)
{
    aw9523_write_reg(client, P0_INT, 0xff);
}

unsigned char aw9523_get_p1(struct i2c_client *client) //该函数用来读取P1端口上的电平状态
{
	unsigned char val;
	aw9523_read_reg(client, P1_INPUT,&val);
    return val;
}

void aw9523_set_p0(struct i2c_client *client,unsigned char data)
{
    aw9523_write_reg(client, P0_OUTPUT, data);
}

void aw9523_set_p1(struct i2c_client *client,unsigned char data)
{
    aw9523_write_reg(client, P1_OUTPUT, data);
}

#ifdef AW9523_DEBUG
void aw9523_test(struct i2c_client *client)
{ 
	unsigned char val;
	
	printk(KERN_ERR "<<<<<<<<<9523 reg dump>>>>>>>>\n");

	aw9523_read_reg(client, ID_REG, &val);
	printk(KERN_ERR"ID_REG=0x%x\n",val);
	aw9523_read_reg(client, P0_INPUT, &val);
	printk(KERN_ERR"P0_INPUT=0x%x\n",val);
	aw9523_read_reg(client, P1_INPUT, &val);
	printk(KERN_ERR"P1_INPUT=0x%x\n",val);
	aw9523_read_reg(client, P0_OUTPUT, &val);
	printk(KERN_ERR"P0_OUTPUT=0x%x\n",val);
	aw9523_read_reg(client, P1_OUTPUT, &val);
	printk(KERN_ERR"P1_OUTPUT=0x%x\n",val);
	aw9523_read_reg(client, P0_CONFIG, &val);
	printk(KERN_ERR"P0_CONFIG=0x%x\n",val);
	aw9523_read_reg(client, p1_CONFIG, &val);
	printk(KERN_ERR"p1_CONFIG=0x%x\n",val);
	aw9523_read_reg(client, P0_INT, &val);
	printk(KERN_ERR"P0_INT=0x%x\n",val);
	aw9523_read_reg(client, P1_INT, &val);
	printk(KERN_ERR"P1_INT=0x%x\n",val);
	aw9523_read_reg(client, CTL_REG, &val);
	printk(KERN_ERR"CTL_REG=0x%x\n",val);

}

static void aw9523_test_work(struct work_struct *work)
{
	struct aw9523_kpad_platform_data *pdata = container_of(work,
						struct aw9523_kpad_platform_data, work.work);
	struct i2c_client *client = pdata->client;

	unsigned char val;
	int dbg = 0;

	printk(KERN_ERR "<<<<<<<<<<<<<<<test read ID reg Entry=========================================\n");

	for(dbg=0;dbg<240;dbg++)
	{
		printk(KERN_ERR "<<<<<<<<<9523 test work>>>>>>>>\n");
		aw9523_read_reg(client, ID_REG, &val);
		printk(KERN_ERR"ID_REG=0x%x\n",val);
		msleep(500);
	}
	printk(KERN_ERR "<<<<<<<<<<<<<<<test read ID reg Exit=========================================\n");
}
#endif

void aw9523_init(struct i2c_client *client)
{
	unsigned char val;

	aw9523_read_reg(client, CTL_REG, &val);
    aw9523_write_reg(client, CTL_REG,  val | 0x10); //set p0 port pull-up mode

	aw9523_write_reg(client, P1_INT, 0xff); //disable p1 port irq

	aw9523_read_reg(client, P0_CONFIG, &val);
	aw9523_write_reg(client,P0_CONFIG, val & (~P0_KROW_MASK)); //set p0 port output mode
	aw9523_read_reg(client, p1_CONFIG, &val);
    aw9523_write_reg(client,p1_CONFIG, val | P1_KCOL_MASK); //set p1 port input mode

	aw9523_read_reg(client, P1_INT, &val);
    aw9523_write_reg(client, P1_INT, val & (~P1_KCOL_MASK)); //P1 key line enable interrupt
    aw9523_read_reg(client, P0_INT, &val);
    aw9523_write_reg(client, P0_INT, val | P0_KROW_MASK); //p0 disable interrupt

	aw9523_read_reg(client, P0_OUTPUT, &val);
	aw9523_write_reg(client, P0_OUTPUT, val & (~P0_KROW_MASK)); //P0 key line output 0

    aw9523_read_reg(client, P0_INPUT, &val); //clear p0 input interrupt
    aw9523_read_reg(client, P1_INPUT, &val); //clear p1 input interrupt


	/*
	Init RGB LED
	    Set P1_LED_MODE register to led model.
	    P1_LED_MODE:This register is LED or GPIO mode switch.
	    Set the register P1_0~P1_2 to 0 (1: gpio 0: led)
	    reg P1_0~P1_2:   P1_0_DIM0   P1_1_DIM0   P1_0_DIM0
	*/
	//aw9523_read_reg(client, P1_LED_MODE, &val);
	//aw9523_write_reg(client,P1_LED_MODE,val & 0xf8);
	aw9523_write_reg(client,P1_LED_MODE,0xF4);
	aw9523_write_reg(client,P0_LED_MODE,0xFC);
	aw9523_write_reg(client,0x11,0x00);//CTL_REG

	//aw9523_write_reg(client,P1_0_DIM0,0x3F);
	//aw9523_write_reg(client,P1_1_DIM0,0x3F);
	//aw9523_write_reg(client,P1_3_DIM0,0x3F);
	//aw9523_write_reg(client,P0_0_DIM0,0x3F);
	//aw9523_write_reg(client,P0_1_DIM0,0x3F);



}


void aw9523_RGBled_color(int r, int g, int b)
{
	struct i2c_client *client = g_aw9523_data->client;

	aw9523_write_reg(client, P1_1_DIM0, r); //color_R
	aw9523_write_reg(client, P1_2_DIM0, g); //color_G
	aw9523_write_reg(client, P1_0_DIM0, b); //color_B
}

static ssize_t aw9523_led_store(struct device *dev,
			      struct device_attribute *attr,
			      const char *buf, size_t size)
{
	const char *delim = ","; //example: "255,10,5".
	char *token, *cur;
	int color_R;
	int color_G;
	int color_B;
	int i = 0;
	cur = kstrdup(buf, GFP_KERNEL);
		
	for(i=0; i<3; i++)
	{
		token = strsep(&cur, delim);
		if (token == NULL)
			break;

		if(i==0)
		{
			color_R = simple_strtoll(token, NULL, 0);
			continue;
		}
		if(i==1)
		{
			color_G = simple_strtoll(token, NULL, 0);
			continue;
		}
		if(i==2)
		{
			color_B = simple_strtoll(token, NULL, 0);
			continue;
		}
	}
	aw9523_RGBled_color(color_R, color_G, color_B);

    return size;
}

DEVICE_ATTR(aw9523_led, S_IWUSR | S_IRUGO, NULL, aw9523_led_store);

static int keyboard_get_press_key(struct i2c_client *client,int *code, int *value)
{
	KEY_STATE *keymap;
	int size;
	unsigned char get_p1=0xff; 
	unsigned char val = 0;
	int row = 0;
	int col = 0;
	int count = 0;

	struct aw9523_kpad_platform_data *pdata;

	pdata = i2c_get_clientdata(client);
	keymap = pdata->keymap;
	size = pdata->keymap_len;

	get_p1 = aw9523_get_p1(client); //get p1   0->低; 1->高

	get_p1 &= P1_KCOL_MASK;
	
	if(get_p1 != P1_KCOL_MASK){ /*some key push down*/
		count=0;
		col = 0;
		get_p1 = (~get_p1) & P1_KCOL_MASK;
		/**********sum col number**********/
		while(get_p1){
			if(get_p1 & 0x01){
				count++;
			}
			get_p1 = get_p1>>1;
			col++;
		}
		if(count > 1){
			return -1;/*one more key push down,give up*/
		}
		
		/***********sum row number**********/
		count=0;
		val = 0;
		while(count <= 8){
			if(P0_KROW_MASK & (0x01<<count)){
				aw9523_read_reg(client, P0_OUTPUT, &val);
				val = (~P0_KROW_MASK) & val; //clear P0 mask
				val = val | (P0_KROW_MASK & (~(0x01<<count))); //set some row line to 0
				aw9523_set_p0(client, val);
				get_p1 = aw9523_get_p1(client);
				get_p1 &= P1_KCOL_MASK;
				if(get_p1 != P1_KCOL_MASK){
					row = count+1;
					break;
				}
			}
			count++;
		}
		if(count > 8){ //can not found row
			return -1;
		}
		/*key valid?*/
		for(count=0; count < size; count++){
			if((keymap[count].row == row) && (keymap[count].col == col)){
				/*found valid key*/
				break;
			}
		}
		
		if(count >= size){ //invalid key
			return -1;
		}
		
		if( keymap[count].key_val > 0){
			return 0;
		}
		else{
			*value =keymap[count].key_val = 1;
			*code = keymap[count].key_code;
			// input_set_capability(pdata->input, EV_KEY, keymap[count].key_code);//add by 
			return 1;
		}
		
	}
	else{ //maybe some key release
		for(count=0; count < size; count++){
			if(keymap[count].key_val > 0){
				/*found key release*/
				break;
			}
		}
		if(count >= size){
			return -1;
		}
		else{
			*code = keymap[count].key_code;
			// input_set_capability(pdata->input, EV_KEY, keymap[count].key_code);//add by 
			keymap[count].key_val = 0;
			*value = 0;
			return 1;
		}
	}
	return -1;
 
} 

static void aw9523_work(struct work_struct *work)
{
	struct aw9523_kpad_platform_data *pdata = container_of(work,
						struct aw9523_kpad_platform_data, work.work);
	struct i2c_client *client = pdata->client;
	int key,ret,key_val;
	unsigned char val = 0;
	//printk(KERN_ERR"----------aw9523_work--\n");
	aw9523_read_reg(client, P1_INT, &val);
	aw9523_write_reg(client, P1_INT, 0xff); //p1 port disable interrupt 
	
        ret = keyboard_get_press_key(client, &key, &key_val);
	printk(KERN_ERR"----------aw9523_work--ret=%d,key=%d,key_val=%d\n",ret,key,key_val);

	if(ret > 0){
		input_report_key(pdata->input,key, key_val);
		input_sync(pdata->input);
	}

    aw9523_read_reg(client, P0_OUTPUT, &val);
    aw9523_write_reg(client, P0_OUTPUT, val &(~P0_KROW_MASK)); //p0 key line output 0

	aw9523_read_reg(client, P1_INT, &val);
	aw9523_write_reg(client, P1_INT, val & (~P1_KCOL_MASK)); //p1 keyline enable interrupt 
	
	#ifdef AW9523_DEBUG
	aw9523_test(client);
	#endif
	
}
 
static irqreturn_t aw9523_irq(int irq, void *handle)
{
	struct i2c_client *client = handle;
	struct aw9523_kpad_platform_data *pdata;

	pdata = i2c_get_clientdata(client);

	 //use keventd context to read the event fifo registers
	 //Schedule readout at least 25ms after notification for
	 // REVID < 4
	
	schedule_delayed_work(&pdata->work, msecs_to_jiffies(pdata->delay));
	
	return IRQ_HANDLED;
}

#ifdef AW9523_DEBUG
static irqreturn_t aw9523_test_irq(int irq, void *handle)
{
	struct i2c_client *client = handle;
	struct aw9523_kpad_platform_data *pdata;

	pdata = i2c_get_clientdata(client);
	
	printk(KERN_ERR "================================aw9523_test_irq \n");
	schedule_delayed_work(&pdata->work, msecs_to_jiffies(10));

	return IRQ_HANDLED;
}
#endif

static void aw9523_led_set_red_1(struct led_classdev *led_cdev,
			       enum led_brightness value)
{
	struct i2c_client *client = g_aw9523_data->client;

	if (value > MAX_RGBLED_VALUE)
		value = MAX_RGBLED_VALUE;
	pr_debug(KERN_INFO "aw9523_led_set_red_1  value=:%d\n", value);
	aw9523_write_reg(client, P0_1_DIM0, value);
	//
}

static void aw9523_led_set_green_1(struct led_classdev *led_cdev,
			       enum led_brightness value)
{
	struct i2c_client *client = g_aw9523_data->client;

	if (value > MAX_RGBLED_VALUE)
		value = MAX_RGBLED_VALUE;
	pr_debug(KERN_INFO "aw9523_led_set_green_1 value=:%d\n", value);

	aw9523_write_reg(client, P0_0_DIM0, value);
}

static void aw9523_led_set_blue_1(struct led_classdev *led_cdev,
			       enum led_brightness value)
{
	//struct i2c_client *client = g_aw9523_data->client;
	int value1=0;
	
	if (value > 0){
		value1 = 0;
	}else if (value == 0){
		value1 = 1;
	}
	
	pr_debug(KERN_INFO "aw9523_led_set_blue_1  value1=:%d\n", value1);
	
	gpio_direction_output(g_aw9523_data->pwm_gpio, value1);
	 //aw9523_write_reg(client, P1_3_DIM0, value);
}

//--------------------------------------
static void aw9523_led_set_red(struct led_classdev *led_cdev,
			       enum led_brightness value)
{
	struct i2c_client *client = g_aw9523_data->client;

	if (value > MAX_RGBLED_VALUE)
		value = MAX_RGBLED_VALUE;
	pr_debug(KERN_INFO "aw9523_led_set_red   value=:%d\n", value);
	
	aw9523_write_reg(client, P1_1_DIM0, value);
}

static void aw9523_led_set_green(struct led_classdev *led_cdev,
			       enum led_brightness value)
{
	struct i2c_client *client = g_aw9523_data->client;

	if (value > MAX_RGBLED_VALUE)
		value = MAX_RGBLED_VALUE;
	pr_debug(KERN_INFO "aw9523_led_set_green  value=:%d\n", value);
       
	aw9523_write_reg(client, P1_0_DIM0, value);
}

static void aw9523_led_set_blue(struct led_classdev *led_cdev,
			       enum led_brightness value)
{
	struct i2c_client *client = g_aw9523_data->client;
	
	if (value > MAX_RGBLED_VALUE)
		value = MAX_RGBLED_VALUE;
	
	pr_debug(KERN_INFO "aw9523_led_set_blue  value=:%d\n", value);
	aw9523_write_reg(client, P1_3_DIM0, value);
}

/*
static void aw9523_button_backlight(struct led_classdev *led_cdev,
			       enum led_brightness value)
{
	int tmp_value = 0;
	printk(KERN_ERR"aw9523_button_backlight---value=%d\n",value);
	if (value >= 1)
		tmp_value = 0;
	if(value <= 0)
		tmp_value = 1;
	
	gpio_set_value(g_aw9523_data->pwm_gpio, tmp_value);

	pr_debug("value=:%d\n", tmp_value);
}*/

static struct led_classdev aw9523RGB_led[NO_LEDS] = {
	[COLOR_R] = {
		.name		= "aw9523_led_red",
		.max_brightness = MAX_RGBLED_VALUE,
		.brightness_set	= aw9523_led_set_red,
	},
	[COLOR_G] = {
		.name		= "aw9523_led_green",
		.max_brightness = MAX_RGBLED_VALUE,
		.brightness_set	= aw9523_led_set_green,
	},
	[COLOR_B] = {
		.name		= "aw9523_led_blue",
		.max_brightness = MAX_RGBLED_VALUE,
		.brightness_set	= aw9523_led_set_blue,
	},
	[COLOR_RED] = {
		.name		= "aw9523_led_set_red",
		.max_brightness = MAX_RGBLED_VALUE,
		.brightness_set	= aw9523_led_set_red_1,
	},
	[COLOR_GREEN] = {
		.name		= "aw9523_led_set_green",
		.max_brightness = MAX_RGBLED_VALUE,
		.brightness_set	= aw9523_led_set_green_1,
	},
	[COLOR_BLUE] = {
		.name		= "aw9523_led_set_blue",
		.max_brightness = MAX_RGBLED_VALUE,
		.brightness_set	= aw9523_led_set_blue_1,
	},
};

/*static struct led_classdev aw9523button_backlight = {
	.name		= "button-backlight",
	.max_brightness = 1,
	.brightness_set = aw9523_button_backlight,
};
*/


static int aw9523_probe(struct i2c_client *client,
			 const struct i2c_device_id *id)
{
	struct aw9523_kpad_platform_data *pdata = client->dev.platform_data;
	int error;
	int ret = 0;
	int i =0;

	if (!i2c_check_functionality(client->adapter,
					I2C_FUNC_SMBUS_BYTE_DATA)) {
		dev_err(&client->dev, "SMBUS Byte Data not Supported\n");
		return -EIO;
	}
	
	pdata = devm_kzalloc(&client->dev,sizeof(struct aw9523_kpad_platform_data), GFP_KERNEL);
	if (!pdata) 
	{
		dev_err(&client->dev, "Failed to allocate memory\n");
		return -ENOMEM;
	}
	g_aw9523_data = pdata;
	/*irq pull power supply*/
		pdata->irq_pull = regulator_get(&client->dev, "irq_pull");
	if (IS_ERR(pdata->irq_pull)) {
		ret = PTR_ERR(pdata->irq_pull);
		dev_err(&client->dev, "Regulator get failed irq_pull ret=%d\n", ret);
		return ret;
	}

	if (regulator_count_voltages(pdata->irq_pull) > 0) {
		ret = regulator_set_voltage(pdata->irq_pull, 1800000,1800000);
		if (ret) {
			dev_err(&client->dev, "Regulator set failed irq_pull ret=%d\n", ret);
			return ret;
		}
	}
	
	ret = regulator_enable(pdata->irq_pull);
	if (ret) {
		dev_err(&client->dev, "Regulator irq_pull enable failed ret=%d\n", ret);
		ret = regulator_disable(pdata->irq_pull);
		return ret;
	}
	else {
		dev_info(&client->dev, "Regulator irq_pull enable success!\n");
	}

	/******end*****/
	pdata->pinctrl = devm_pinctrl_get(&client->dev);
	if (IS_ERR(pdata->pinctrl)) {
		pr_err("%s:failed to get pinctrl\n", __func__);
		return -EINVAL;
	}

	pdata->dis_state_default = pinctrl_lookup_state(pdata->pinctrl, "aw9523_reset_default");
	if (IS_ERR(pdata->dis_state_default)) {
		pr_err("%s:can not get reset pinstate\n", __func__);
		return -EINVAL;
	}

	ret= pinctrl_select_state(pdata->pinctrl, pdata->dis_state_default);
	if (ret){
		pr_err("%s:set reset pin state failed!\n", __func__);
	}

	pdata->irq_state_default = pinctrl_lookup_state(pdata->pinctrl, "aw9523_int_default");
	if (IS_ERR(pdata->irq_state_default)) {
		pr_err("%s:can not get irq pinstate\n", __func__);
		return -EINVAL;
	}

	ret = pinctrl_select_state(pdata->pinctrl, pdata->irq_state_default);
	if (ret){
		pr_err("%s:set irq pin state failed!\n", __func__);
	}

	pdata->dis_gpio = of_get_named_gpio(client->dev.of_node, "qcom,dis-gpio", 0);
		printk(KERN_ERR"--aw9523_probe--pdata->dis_gpio=%d\n",pdata->dis_gpio);

	if ((!gpio_is_valid(pdata->dis_gpio))){
			return -EINVAL;
	}

	ret = gpio_request(pdata->dis_gpio, "aw9523-reset-keys");
	if (ret) {
		dev_err(&client->dev, "unable to request gpio [%d]\n",
			pdata->dis_gpio);
		goto err_dis_gpio;
	}

	ret = gpio_direction_output(pdata->dis_gpio, 1);
	if (ret) {
		dev_err(&client->dev, "unable to set direction for gpio [%d]\n",
			pdata->dis_gpio);
		goto err_dis_gpio;
	}

	gpio_set_value(pdata->dis_gpio, 0); /* ULPM */
	msleep(1);
	gpio_set_value(pdata->dis_gpio, 1); /* HPD */

	/*kp-led gpio control*/
	pdata->pwm_gpio = of_get_named_gpio(client->dev.of_node, "qcom,mdss-dsi-pwm", 0);
	if ((!gpio_is_valid(pdata->pwm_gpio))){
			return -EINVAL;
	}
	printk(KERN_ERR"---pdata->pwm_gpio=%d\n",pdata->pwm_gpio);
	ret = gpio_request(pdata->pwm_gpio, "aw9523-led-gps");
	if (ret) {
		dev_err(&client->dev, "unable to request gpio [%d]\n",
			pdata->pwm_gpio);
		//goto err_pwm_gpio;
	}

	ret = gpio_direction_output(pdata->pwm_gpio, 1);
	if (ret) {
		dev_err(&client->dev, "unable to set direction for gpio [%d]\n",
			pdata->pwm_gpio);
		//goto err_pwm_gpio;
	}
	/*end*/

	
	pdata->input = input_allocate_device();
	if (!pdata->input) {
		error = -ENOMEM;
		goto err_free_mem;
	}

	pdata->client = client;
	INIT_DELAYED_WORK(&pdata->work, aw9523_work);
	#ifdef AW9523_DEBUG
	INIT_DELAYED_WORK(&pdata->work, aw9523_test_work);
	#endif
	pdata->input->name = "aw9523-keys";	
	pdata->input->phys = "aw9523-keys/input0";
	pdata->input->dev.parent = &client->dev;
	pdata->keymap_len = sizeof(key_map)/sizeof(KEY_STATE);
	pdata->keymap = (KEY_STATE *)&key_map;

	input_set_drvdata(pdata->input, pdata);

	__set_bit(EV_KEY, pdata->input->evbit);
	//__set_bit(EV_SYN, pdata->input->evbit);

	for (i = 0; i < pdata->keymap_len; i++)
		__set_bit(pdata->keymap[i].key_code & KEY_MAX, pdata->input->keybit);

	input_set_capability(pdata->input, EV_KEY, KEY_0);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_1);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_2);//add by
	
	input_set_capability(pdata->input, EV_KEY, KEY_3);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_4);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_5);//add by

	input_set_capability(pdata->input, EV_KEY, KEY_6);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_7);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_8);//add by

	input_set_capability(pdata->input, EV_KEY, KEY_9);//add by


	input_set_capability(pdata->input, EV_KEY, KEY_ENTER);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_LEFT);//add by
	input_set_capability(pdata->input, EV_KEY, KEY_RIGHT);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_UP);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_DOWN);//add by 
		
	input_set_capability(pdata->input, EV_KEY, KEY_BACKSPACE);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_MENU);//add by
	input_set_capability(pdata->input, EV_KEY, KEY_BACK);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_SCALE);//add by 
	
	input_set_capability(pdata->input, EV_KEY, KEY_SWITCHVIDEOMODE);//add by 
	input_set_capability(pdata->input, EV_KEY, KEY_KBDILLUMTOGGLE);//add by 

	input_set_capability(pdata->input, EV_KEY, KEY_F1);//add by
	input_set_capability(pdata->input, EV_KEY, KEY_F2);//add by
	input_set_capability(pdata->input, EV_KEY, KEY_F3);//add by
	input_set_capability(pdata->input, EV_KEY, KEY_F4);//add by
	input_set_capability(pdata->input, EV_KEY, KEY_F5);//add by
	input_set_capability(pdata->input, EV_KEY, KEY_F6);//add by


	error = input_register_device(pdata->input);
	if (error) {
		dev_err(&client->dev, "unable to register input device\n");
		goto err_free_mem;
	}

	pdata->delay = 50; //1;
	
	
	 
	mutex_init(&pdata->read_write_lock);

	pdata->irq_gpio = of_get_named_gpio(client->dev.of_node, "qcom,irq-gpio", 0);
		printk(KERN_ERR"--aw9523_probe--pdata->irq_gpio=%d\n",pdata->irq_gpio);
	if ((!gpio_is_valid(pdata->irq_gpio))){
			return -EINVAL;
	}
	printk(KERN_ERR"----pdata->irq_gpio=%d\n",pdata->irq_gpio);
	ret = gpio_request(pdata->irq_gpio, "aw9523-keys");
	if (ret) {
		dev_err(&client->dev, "unable to request gpio [%d]\n",
			pdata->irq_gpio);
		goto err_dis_gpio;
	}
	
	ret = gpio_direction_input(pdata->irq_gpio);
	if (ret) {
		dev_err(&client->dev, "unable to set direction for gpio [%d]\n",
			pdata->irq_gpio);
		goto err_irq;
	}
	
	client->irq = gpio_to_irq(pdata->irq_gpio);
	if (client->irq < 0) {
		ret = client->irq;
		goto err_irq;
	}
	/*RGB LED control file create*/
	for(i=0; i<NO_LEDS; i++)
	{
		if(led_classdev_register(&client->dev, &aw9523RGB_led[i]))
		pr_err("led_classdev_register aw9523RGB_led failed\n");
	}
	/*button backlight control file create*/
	
	//if(led_classdev_register(&client->dev, &aw9523button_backlight))
	//pr_err("led_classdev_register aw9523button_backlight failed\n");
	
	ret = device_create_file(&client->dev, &dev_attr_aw9523_led);
	if (ret)
		goto err_create_file;

	ret = devm_request_threaded_irq(&client->dev, client->irq, NULL,
		aw9523_irq, IRQF_TRIGGER_FALLING | IRQF_TRIGGER_RISING | IRQF_ONESHOT,
		"aw9523_irq", client);
	if (ret) {
	dev_err(&client->dev, "Failed aw9523 irq=%d request ret = %d\n",
		client->irq, ret);
		goto err_irq;
	}
	#ifdef AW9523_DEBUG
	ret = devm_request_threaded_irq(&client->dev, client->irq, NULL,
		aw9523_test_irq, IRQF_TRIGGER_FALLING | IRQF_TRIGGER_RISING | IRQF_ONESHOT,
		"aw9523_test_irq", client);
	#endif
	enable_irq_wake(client->irq);

	device_init_wakeup(&client->dev, 1);
	i2c_set_clientdata(client, pdata);

	dev_info(&client->dev, "Rev. keypad, irq %d\n",client->irq);

    aw9523_init(client);
	
	return 0;

err_irq:
	gpio_free(pdata->irq_gpio);
err_dis_gpio:
	gpio_free(pdata->dis_gpio);
//err_pwm_gpio:
//	gpio_free(pdata->pwm_gpio);
 err_free_mem:
	input_free_device(pdata->input);
	kfree(pdata);
err_create_file:
	device_remove_file(&client->dev, &dev_attr_aw9523_led);

	return error;
}

static int aw9523_remove(struct i2c_client *client)
{
	struct aw9523_kpad_platform_data *kpad = i2c_get_clientdata(client);

	aw9523_write_reg(client, 0x00, 0);
	free_irq(client->irq, kpad);
	cancel_delayed_work_sync(&kpad->work);
	input_unregister_device(kpad->input);
	kfree(kpad);
	return 0;
}

static const struct of_device_id aw9523_keypad_of_match[] = {
	{ .compatible = "qcom,aw9523-keys",},
	{},
};

static const struct i2c_device_id aw9523_id[] = {
	{"aw9523-keys", 0},
	{},
};
MODULE_DEVICE_TABLE(i2c, aw9523_id);

static struct i2c_driver aw9523_driver = {
	.driver = {
		.name = "aw9523-keys",
		.owner		= THIS_MODULE,
		.of_match_table = aw9523_keypad_of_match,
	},
	.probe    = aw9523_probe,
	.remove   = aw9523_remove,
	.id_table = aw9523_id,
};

module_i2c_driver(aw9523_driver);

MODULE_AUTHOR("Wu Guang <wuguang@forgechina.com.cn>");
MODULE_DESCRIPTION("Aw9523 Keypad driver");
MODULE_LICENSE("GPL");
MODULE_ALIAS("i2c:aw9523-keys");
