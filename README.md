# MyComputerTools

A tool for remotely controlling computers

## features
 1. RESTART COMPUTER
 1. RESTART EXPLORER
 1. GET_PICTURE

### RESTART COMPUTER
USE `Process.Start("shutdown.exe","-r -t 10");`
### RESTART EXPLORER
USE 
````
  Process[] processAlls=Process.GetProcessesByName("explorer");
			if(processAlls.Length>0){
				Debug.WriteLine(processAlls[0].ProcessName);
				//processAlls[0].Close();
				processAlls[0].Kill();
				//processAlls[0].Start();
			}
````

### GET_PICTURE
 Get full screen screenshot
### IMALIVE
Send IMALIVE.
2 step:

1. get pic id,
2. post pic
