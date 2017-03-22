//****************************包含头文件***************************/
#include "reg52.h"
#include "intrins.h"
#include "IC.h"
#include "Delay.h"
//
//
#define Interface_IIC   //定义通信方式接口8080、IIC、SPI
//
//

#ifdef  Interface_8080

/**********************************************
//
//写命令函数

**********************************************/
//
//

void Write_Command(uchar command)
{
   CS=low;
   DC=low;
   WR=low;
   _nop_();_nop_();
   P0=command;
   WR=high;
   _nop_();_nop_();
   CS=high;
}

//
//
//
/**********************************************
//
//写数据函数
//
**********************************************/
//
//
void Write_Data(uchar date)
{
   CS=low;
   DC=high;
   WR=low;
   _nop_();_nop_();
   P0=date;
   WR=high;
   _nop_();_nop_();
   CS=high;
}

#endif

#ifdef  Interface_IIC

/**********************************************
//
//IIC通信开始函数
//
**********************************************/

void IC_IIC_Start()
{
   SDA = high;
   SCL = high;
   _nop_();
   SDA = low;
   _nop_();_nop_();
   SCL = low;
}

/**********************************************
//
//IIC通信停止函数
//
**********************************************/

void IC_IIC_Stop()
{
   SDA = low;
   _nop_();
   SCL = high;
   _nop_();_nop_();
   SDA = high;
}

/**********************************************
//
//向IIC写数据函数
//返回值为acknowledgement位信号
//
**********************************************/

bit Write_IIC_Data(uchar Data)
{
	unsigned char i;
	bit Ack_Bit;                    //应答信号
	for(i = 0; i < 8; i++)		
	{
		SDA = (bit)(Data & 0x80);
		_nop_();
		SCL = high;
		_nop_();_nop_();
		SCL = low;
		Data = _crol_(Data,1);
	}
	SDA = high;		                //释放IIC SDA总线为主器件接收从器件产生应答信号	
	_nop_();_nop_();
	SCL = high;                     //第9个时钟周期
	_nop_();_nop_();
	Ack_Bit = SDA;		            //读取应答信号
	SCL = low;
	return Ack_Bit;		
}

/**********************************************
//
//写命令函数

**********************************************/
//
//

void Write_Command(uchar command)
{
   IC_IIC_Start();
   Write_IIC_Data(Slave_Address);                //Salve Adress
   Write_IIC_Data(OP_Command);                   //写命令
   Write_IIC_Data(command); 
   IC_IIC_Stop();
}

/**********************************************
//
//写数据函数
//
**********************************************/
//
//

void Write_Data(uchar date)
{
   IC_IIC_Start();
   Write_IIC_Data(Slave_Address);                //Salve Adress
   Write_IIC_Data(OP_Data);                      //写数据
   Write_IIC_Data(date);
   IC_IIC_Stop();
}


#endif

#ifdef  Interface_SPI

/**********************************************
//
//写命令函数

**********************************************/
//
//

void Write_Command(uchar command)
{
   uchar i,value;
   value = command;
   CS = low;
   DC = low;
   for(i=0;i<8;i++)
   {
     SCL = low;
	 _nop_(); _nop_();
     if(value & 0x80) SI = high;
	 else  SI = low;
	 SCL = high;
	 _nop_(); _nop_();
	value =  _crol_(value, 1);
   }
   CS = high;
}

//
//

/**********************************************
//
//写命令函数

**********************************************/
//
//

void Write_Data(uchar date)
{
   uchar i,value;
   value = date;
   CS = low;
   DC = high;
   for(i=0;i<8;i++)
   {
     SCL = low;
	 _nop_(); _nop_();
     if(value & 0x80) SI = high;
	 else  SI = low;
	 SCL = high;
	 _nop_(); _nop_();
	value =  _crol_(value, 1);
   }
   CS = high;
}

#endif
/******************************************************
//
//复位IC函数
//
******************************************************/
//
//

void Reset_IC()
{
   Delay_Ms(10);
   LED_Work = low;
   RES = low;
   Delay_Ms(50);
   RES = high;
   Delay_Ms(100);
   VCC_Change = high;
}

/******************************************************
//
//初始化IC函数
//
******************************************************/
//
//

void Init_IC()
{

   Write_Command(0xae);    //Display OFF  
  
   Write_Command(0xd5);    // Set Dclk    
   Write_Command(0x90);    //100Hz    

   Write_Command(0x20);    // Set row address  
  
   Write_Command(0x81);    // Set contrast control    
   Write_Command(0xc0);    

   Write_Command(0xa0);    // Segment remap  
  
   Write_Command(0xa4);    // Set Entire Display ON
    
   Write_Command(0xa6);    // Normal display   
 
   Write_Command(0xad);    // Set external VPP    
   Write_Command(0x80);    

   Write_Command(0xc0);    // Set Common scan direction 
   
   Write_Command(0xd9);    // Set phase leghth    
   Write_Command(0x1f);    

   Write_Command(0xdb);    // Set Vcomh voltage    
   Write_Command(0x28);    // 0.738*VPP  
 
   Write_Command(0xaf);     //Display ON 

}






void display_white(void)
{
  unsigned int j,i;

  for(i=0xB0;i<0xB0+16;i++)
    {
	Write_Command(i);
	Write_Command(0x00);
        Write_Command(0x10);
	for(j=0;j<128;j++)
    Write_Data(0xff);	  
	}
      
}



