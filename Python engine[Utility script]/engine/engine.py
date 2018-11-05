import time
import os

#Text functions
class Text:
	def Print(text):
		print(text)
	def NewLine():
		print("")
class System:
	def Clear():
		os.system('cls')
class Utility:
	def Sleep(s):
		time.sleep(s)
#Full engine
def Init(verbose = False):
	verbose = bool(verbose)
	try:
		Config = open("engine_config.cfg", "r")
	except:
		print("Engine error: Unable to find engine_config.cfg")
		ErrLog = open("ErrLog.txt", "w")
		ErrLog.write("Engine error: Unable to find engine_config.cfg")
		ErrLog.close()
		exit(-1)
	if verbose == True:
		print("Opened engine_config.cfg in read mode.")
	if Config.read(14) != "[Config Start]":
		ErrLog = open("ErrLog.txt", "w")
		ErrLog.write("Engine error: Invalid start in config.cfg, looked for '[Config Start]', found {}".format(Config.read(14)))
		ErrLog.close()
		exit(-1)
	if Config.readline(2)[:7] != "GameDir":
		ErrLog = open("ErrLog.txt", "w")
		ErrLog.write("Engine error: Could not find expected keyword 'GameDir' on line 2.")
		ErrLog.close()
	GameDir = Config.readline(2)
	# if Config.readline(2)[7:8] != "=":
		# ErrLog = open("ErrLog.txt", "w")
		# ErrLog.write("Engine error: Syntax error on line 2, column 8, Could not find expected char '='.")
		# ErrLog.close()
	print(GameDir)