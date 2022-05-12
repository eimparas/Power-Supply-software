# Using the `SYSTem:STATus?` Command
> THis command sums up the current status of the instrument , in to a hex that you have to proccses based on this : 


The return info is hexadecimal format, but the actual
state is binary, so you must change the return info into a
binary. The state correspondence relationship is as
follow

| Bit No. | Corresponding State |
|---|---|
| 0 | 0: CH1 CV mode; 1:CC Mode |
| 1 | 0: CH2 CV mode; 1: CH2 CC mode |  
|2,3  |  01: Independent mode; 10: Parallel mode 11:Series Mode (fromMemory)|
|4|0: CH1 OFF 1: CH1 ON|
|5|0: CH2 OFF 1: CH2 ON|
|6|0: TIMER1 OFF 1: TIMER1 ON|
|7|0: TIMER2 OFF 1: TIMER2 ON|
|8|0: CH1 digital display; 1: CH1 waveform diplay|
|9|0: CH2 digital display; 1: CH2 waveform diplay|
