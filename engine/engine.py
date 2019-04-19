import time
import os

#Text functions
class Text:
	def Print(text):
		print(text) #Literally just the Generic Print.
	def NewLine():
		print("") #Same for this, just printing nothing to cause a newline.
class System:
	def Clear():
		os.system('cls') #sent the clear screen command, clears the output console.
class Utility:
	def Sleep(s):
		time.sleep(s)#causes a time delay without having to import time (this script does that)
#Full engine
def Init(verbose = False):
	verbose = bool(verbose)
	try:
		Config = open("engine_config.cfg", "r")
	except:
		print("Engine error: Unable to find or read engine_config.cfg")
		ErrLog = open("ErrLog.txt", "w")
		ErrLog.write("Engine error: Unable to find or read engine_config.cfg")
		ErrLog.close()
		exit(-1)
	if verbose == True:
		print("Opened engine_config.cfg in read mode.")
	if Config.read(14) != "[Config Start]":
		ErrLog = open("ErrLog.txt", "w")
		ErrLog.write("Engine error: Invalid start in config.cfg, looked for '[Config Start]', found {}".format(Config.read(14)))
		ErrLog.close()
		exit(-1)
	Config.readline(2) #avoids \n being placed in the string.
	GameDir = Config.readlines()
	GameDir = str(GameDir)[2:-2]
	if verbose == True:
		print("Game directory changing to: " + GameDir)
	if GameDir[0:7] != "GameDir":
		ErrLog = open("ErrLog.txt", "w")
		ErrLog.write("Engine error: Could not find expected keyword 'GameDir' on line 2.")
		ErrLog.close()
	if GameDir[7:8] != "=":
		ErrLog = open("ErrLog.txt", "w")
		ErrLog.write("Engine error: Syntax error on line 2, column 8, Could not find expected char '='.")
		ErrLog.close()
		exit(-1)
	try:
		os.chdir(GameDir[8:])
	except:
		ErrLog = open("ErrLog.txt", "w")
		ErrLog.write("Engine error: Bad directory.")
		ErrLog.close()
		exit(-1)
	if verbose == True:
		print("Changed directory to: " + GameDir[8:])
