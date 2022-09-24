class Board {
    public bool HasBingo {get; set;} = false;
    private int[,] board = new int[5,5];

    public Board(List<int> numArray){
        for(int i = 0; i < 25; i++){
            board[i / 5, i % 5] = numArray[i];
        }
    }

    public void finalAnswer(int num, bool firstWin){
        int sum = 0;
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                if(board[i,j] != -1){
                    sum += board[i,j];
                }
            }
        }
        int answer = sum * num;
        if(firstWin){
            System.Console.WriteLine($"The final answer for #1 is: {answer}");
        } else {
            System.Console.WriteLine($"The final answer for #2 is: {answer}");
        }
    }


    public bool checkBoard(int num){        

        setBoard(num);
        
        if(checkRows() || checkColumns()){
            HasBingo = true;
        }
        return HasBingo;
    }

    public void setBoard(int num){
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                if(board[i,j] == num){
                    board[i,j] = -1;
                }
            }
        }
    }

    public bool checkRows(){
        bool bingo = true;
        for(int i = 0; i < 5; i++){
            bingo = true;
            for(int j = 0; j < 5; j++){
                if(board[i,j] != -1){
                    bingo = false;
                }
            }
            if(bingo){
                return bingo;
            }
        }
        return bingo;
    }

    public bool checkColumns(){
        bool bingo = true;
        for(int i = 0; i < 5; i++){
            bingo = true;
            for(int j = 0; j < 5; j++){
                if(board[j,i] != -1){
                    bingo = false;
                }
            }
            if(bingo){
                return bingo;
            }
        }
        return bingo;
    }

    

    public void printBoard(){
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                if(j == 4){
                    Console.WriteLine(board[i,j]);
                } else {
                    Console.Write(board[i,j] + " ");
                }
            }
        }
        System.Console.WriteLine();
    }
}