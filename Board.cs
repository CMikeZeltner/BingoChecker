class Board {
    private bool HasBingo {get; set;} = false;
    private int[,] board = new int[5,5];

    public Board(List<int> numArray){
        for(int i = 0; i < 25; i++){
            board[i / 5, i % 5] = numArray[i];
        }
    }

    

    public void printBoard(){
        Console.WriteLine("heyyy");
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                if(j == 4){
                    Console.WriteLine(board[i,j]);
                } else {
                    Console.Write(board[i,j] + " ");
                }
            }
        }
    }
}