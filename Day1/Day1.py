InputFile = open("Input.txt", "r")
Input = InputFile.read().splitlines()
for line in Input:
    print(line)
