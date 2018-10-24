import time
import engine

try:
	print("Testing engine:")
	engine.Text.Print("Hello, world!")
	print("Test successful, continuing.")
	time.sleep(1)
except:
	print("Test unsuccessful, exiting in five(5) seconds.")
	time.sleep(5)
	exit(-1)
engine.System.Clear()
engine.Text.Print("ST3VI3 STUDIOS 2018 Engine command line")
engine.Text.NewLine()
while True:
	Command = input(">")
	if Command.lower == "help" or Command == "?":
		engine.Text.NewLine()
		engine.Text.Print("-------------Help-------------")
		engine.Text.Print("Help - The basic help command.")
		engine.Text.NewLine()
	elif Command.lower == "cls" or Command.lower == "clear":
		engine.System.Clear()
	elif Command.lower == "echo":
		engine.Text.Print(command[5])
	else:
		if Command == "":
			0 + 0
		else:
			engine.Text.Print("Unknown command: " + Command)