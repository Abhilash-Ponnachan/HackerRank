<Query Kind="Program" />

void Main()
{
	Func<string> ReadInputLine = ReadInputLineFact();
	
	string[] tokens_H = ReadInputLine().Split(' ');
	int H = Convert.ToInt32(tokens_H[0]);
	int W = Convert.ToInt32(tokens_H[1]);
	int[][] A = new int[H][];
	for (int A_i = 0; A_i < H; A_i++)
	{
		string[] A_temp = ReadInputLine().Split(' ');
		A[A_i] = Array.ConvertAll(A_temp, Int32.Parse);
	}
	//PrintMatrix(A);
	int result = SurfaceArea(A);
	Console.WriteLine(result);
}

int SurfaceArea(int[][] Matrix)
{
	var area = 0;
	var rowCount = Matrix.Length;
	var neighbours = new bool[4];
	for (var i = 0; i < rowCount; i++)
	{
		var row = Matrix[i];
		var colCount = row.Length;
		for (var j = 0; j < colCount; j++)
		{
			var n = row[j];
			var cellArea = (int)(6 * n) - (2 * (n - 1));
			// set neighbours = true
			if(i == 0){
				neighbours[(int)Dirs.Top] = false;					
			}
			else if (i == rowCount){
				neighbours[(int)Dirs.Bottom] = false;	
			}
			
			Console.Write($"{cellArea} ");
		}
		Console.WriteLine();
	}
	return area;
}

void PrintMatrix(int[][] Matrix)
{
	for (var i = 0; i < Matrix.Length; i++)
	{
		var row = Matrix[i];
		for (var j = 0; j < row.Length; j++)
		{
			Console.Write($"{row[j]} ");
		}
		Console.WriteLine();
	}
}

enum Dirs {Left = 0, Top = 1, Right = 2, Bottom = 3}

Func<string> ReadInputLineFact(){
	var li = 0;
	var text = INPUT_TEXT;
	return () => {
		var strBldr = new StringBuilder();
		var len = text.Length;
		while (li < len) {
			var c = text[li];
			strBldr.Append(c);
			li++;
			if (c == '\r')
			{
				if (c == '\n')
				{
					li++;
				}
				break;
			}			
		}
		return strBldr.ToString();
	};
}

const string INPUT_TEXT 
= @"3 3
1 3 4
2 2 3
1 2 4";