
import socket
import time
sock = socket.socket(socket.AF_INET , socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

velocity = 3 #1-9
horizontalVel = 10 # 10-90 (Will be divided by 10 for final horizontalVel)
# spawnGap = 1

while True :
 
 sock.sendto(str.encode( str(velocity)), serverAddressPort)
 print(velocity)
 sock.sendto(str.encode( str(horizontalVel)), serverAddressPort)
 print(horizontalVel)
#  sock.sendto(str.encode("HV" + str(horizontalVel)), serverAddressPort)
#  print(horizontalVel)
#  sock.sendto(str.encode("SG" + str(spawnGap)), serverAddressPort)
#  print(spawnGap)
 time.sleep(1)

                
