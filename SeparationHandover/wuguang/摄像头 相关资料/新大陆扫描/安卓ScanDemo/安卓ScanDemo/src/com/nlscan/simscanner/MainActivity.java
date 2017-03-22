package com.nlscan.simscanner;

import android.app.Activity;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.Build;
import android.os.Bundle;
import android.telephony.TelephonyManager;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends Activity {
    protected static final String TAG = "MainActivity";
	private BroadcastReceiver mReceiver;
    private IntentFilter mFilter;

    private TextView mTvScanResult;
//    private TextView tv_deviceinfo;
    private Button mBtStartScan;
    private EditText et_scanresult;
    
    private String deviceInfo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Log.i(TAG, "oncreate");
        setContentView(R.layout.activity_main);
        
        deviceInfo = "Model = "+Build.MODEL+"\n"
        		+"Manufacturer = "+Build.MANUFACTURER+"\n";

        et_scanresult = (EditText) findViewById(R.id.et_scan_result);
//        tv_deviceinfo = (TextView) findViewById(R.id.tv_deviceinfo);
        mTvScanResult = (TextView) this.findViewById(R.id.tv_scan_result);
        mBtStartScan = (Button) this.findViewById(R.id.bt_start_scan);
        
//        tv_deviceinfo.setText(deviceInfo);

        final Context context = this;
        mBtStartScan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //开启扫描
            	Intent intent = new Intent("ACTION_BAR_TRIGSCAN");
        		intent.putExtra("timeout", 3);
        		sendBroadcast(intent);
            }
        });
        
        mReceiver = new BroadcastReceiver() {
            @Override
            public void onReceive(Context context, Intent intent) {
            	Log.i(TAG, "receive");

                //此处获取扫描结果信息
                final String scanResult = intent.getStringExtra("EXTRA_SCAN_DATA");
                Log.i(TAG, "scanResult = "+scanResult);
                mTvScanResult.setText(scanResult);
                mTvScanResult.invalidate();
                
                et_scanresult.setText(scanResult);
                et_scanresult.invalidate();
            }
        };

        mFilter = new IntentFilter("ACTION_BAR_SCAN");
        //在用户自行获取数据时，将广播的优先级调到最高 1000，***此处必须***
    }

    @Override
    protected void onResume() {
        super.onResume();
      //注册广播来获取扫描结果
        this.registerReceiver(mReceiver, mFilter);
    }

    @Override
    protected void onPause() {
        //注销获取扫描结果的广播
        this.unregisterReceiver(mReceiver);
        super.onPause();
    }

    @Override
    protected void onDestroy() {
        mReceiver = null;
        mFilter = null;
        mTvScanResult = null;
        super.onDestroy();

    }

}
