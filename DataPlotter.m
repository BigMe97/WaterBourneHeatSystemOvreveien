clear
close all
clc
format longG


data = readmatrix('D:\HeatSystemRepository\WaterBourneHeatSystem\HeatSystem\HeatSystem\bin\Debug\net6.0\MixerValues.csv', 'DecimalSeparator', ',', "Delimiter", ";", 'OutputType', 'string');
time = data(:,1)
time = datetime(time,'InputFormat','dd.MM.yy:HH:mm:ss')


Temp = str2double(data(:,2))/100;
Pos = str2double(data(:,3))/100;
maxR = max(Temp)
minR = min(Temp)


figure
plot(time, Temp, 'b', time, Pos);                 % Temperatur over tid
hold on

grid on
xlabel('Time [Date]');
ylabel('Temperature [°C] / Opening[%]');
title('Temperature');
legend('Temperatue', 'Valve Position');
ylim([-2, 105])


