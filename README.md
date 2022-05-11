## Command Set for Siglent`s SPD3303X-E


# Getters

| Command | Expected return |Notes| DataType | Type |Unit
|---|---|---|---|---|---|
| `*IDN?` | {Vendor},{ModelNumber},{SerialNumber},{Firmware Version},{Hardware Revision}|theMostUniversalCommand | String | Getter |N/D|
| `INSTrument?` | CHx |Gets The Active Channel| String | Getter |N/D|
| `MEASure:CURRent? CHx` | 0.00 |ADC reading| Float | Getter | A |
| `MEASure:VOLTage? CHx` | 0.00 |ADC reading| Float | Getter |V |
| `MEASure:POWEr? CHx` | 0.00 |ADC reading or instrument calc| Float | Getter |W|
| `CHx:CURRent?` | 0.00 |Set value| Float | Getter |A|
| `CHx:VOLTage?` |0.00 |Set value| Float | Getter |V|
|`SYSTem:STATus?`|0xSOMETHING|see [SystemStatus.md](SystemStatus.md) for details  **THISISTHEDEVILHIMSELF**|HEX|Getter|N/D

# Setters

| Command | Expected return |Notes| DataType | Type |Unit
|---|---|---|---|---|---|
| `INSTrument CHx` | n/a | - |-| Setter |N/D|
|`CHx:CURRent {VAL}`|n/a|sets the CC|Float|Setter|A|
|`CHx:VOLTage {VAL}`|n/a|sets the output Voltage|Float|Setter|V|
|`OUTPut CHx,{ON/OFF}`|n/a|Turn on/off the specified channel|-|Setter|N/D|
|`OUTPut:TRACK {0/1/2}`|n/a|Sets the channel mode on Indie, Serial or Paralel|-|Setter|N/D|
|`OUTPut:WAVE CHx,{ON/OFF}`|n/a| Turn on/off the Waveform Display function of specified channel.|-|Setter|N/D|
|`*SAV {1/2/3/4/5}`|n/a|Save current state in nonvolatile memory|-|Setter|N/D|
|`*RCL {1/2/3/4/5}`|n/a|Recall state that had been saved from nonvolatile memory.|-|Setter|N/D|

* IP setup

# Getters

|Command|Expected return|Description|Type|
|---|---|---|---|
|`DHCP?`|DHCP:ON|Query whether the automatic network parameters configuration function is turn on|Getter|
|`IPaddr?`|192.168.0.106|Query the current IP address of the instrument|Getter|
|`MASKaddr?`|255.255.255.0|Query the current subnet mask of the instrument|Getter|
|`GATEaddr?`|192.168.0.1|Query the current gateway of the instrument|Getter|


# Setters
|Command|Expected return|Description|Type|
|---|---|---|---|
|`DHCP {ON/OFF}`|n/a|Assign the network parameters (such as the IP address)for the instrument automatically.|Setter|
|`IPaddr {IP address}`|n/a|Assign a static Internet Protocol (IP) address for the instrument Note,Invalid when DHCP is on|Setter|
|`MASKaddr {NetMasK}`|n/a|Assign a subnet mask for the instrument Note,Invalid when DHCP is on|Setter|
|`GATEaddr {GateWay}`|n/a|Assign a gateway for the instrument Note,Invalid when DHCP is on|Setter|
