public class Board
{
	private Piece[,] _board;
	private int _number;
	private int _letter;

	public Board(Location loc)
	{
	_board = new Piece[8,8];
	_board[0,0] = new Rook(false);
	_board[0,1] = new Rook(true);
	SetSelected(loc);	
	}
	public void Display()
	{
		for(int i = 0; i < 8;i++)
		{
			Console.Write(i+1+" ");
			for(int j = 0;j < 8;j++)
			{
				if(_letter == j && _number == i){
						Console.ForegroundColor = ConsoleColor.Magenta;
					}
				if(_board[i,j] != null){
					
					Console.Write($"[{_board[i,j].ToString()}]");
				}
				else
					Console.Write("[ ]");	
				Console.ResetColor();

			}
			Console.WriteLine();
		}
		Console.WriteLine("   A  B  C  D  E  F  G  H");
	}
	
	public void SetSelected(int n,int l)
	{
		_number = n;
		_letter = l;
	}
	public void SetSelected(Location l)
	{
		_number = l.GetNum();
		_letter = (int)l.GetLetter() - 65;
	}
}
