public class Board
{
	private Piece[,] _board;

	public Board()
	{
	_board = new Piece[8,8];
	_board[0,0] = new Rook(false);
	_board[0,1] = new Rook(true);
	}
	public void Display()
	{
		for(int i = 0; i < 8;i++)
		{
			Console.Write(i+1+" ");
			for(int j = 0;j < 8;j++)
			{
				if(_board[i,j] != null){
				Console.Write($"[{_board[i,j].ToString()}]");	
				}
				else
					Console.Write("[ ]"); 

			}
			Console.WriteLine();
		}
		Console.WriteLine("   A  B  C  D  E  F  G  H");
	}
}
