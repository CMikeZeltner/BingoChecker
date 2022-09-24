class BoardHandler{

    List<Board> boards;
    Draws draws;
    StreamReader sr;

    public BoardHandler(){
        sr = new StreamReader(@"C:\Users\12152\Documents\Projects\csharp\Bingo\input.txt");
        boards = new List<Board>();
        draws = new Draws(setDraws());
        setBoards();
    }

    public void gameLoop(){

        int currDraw = 0;
        int winningBoards = 0;
        bool bingo = false;
        bool lastBingo = false;

        while(!lastBingo){
            currDraw = draws.drawNumber();

            //System.Console.WriteLine(currDraw);

            for(int i = 0; i < boards.Count; i++){
                if(!boards[i].HasBingo){
                    bingo = boards[i].checkBoard(currDraw);
                    if(bingo && winningBoards == 0){
                        winningBoards++;
                        boards[i].finalAnswer(currDraw, true);
                    }  else if (bingo && winningBoards == boards.Count - 1){
                        boards[i].finalAnswer(currDraw, false);
                        winningBoards++;
                        lastBingo = true;
                    } else if (bingo){
                        winningBoards++;
                    }
                }
            }
        }

        // boards.ForEach(board => {
        //     board.printBoard();
        // });
            //boards[firstWin].finalAnswer(currDraw, true);
            //boards[lastWin].finalAnswer(currDraw, false);
    }

    

    public void setBoards(){
        string line = "";
        List<int> boardNums = new List<int>();
        int[] tempArray;

            while((line = sr.ReadLine()) != null)
            {

                if(line == ""){
                 boards.Add(new Board(boardNums));
                 boardNums.Clear();
                } else {

                 tempArray = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                 foreach(int num in tempArray){
                    boardNums.Add(num);
                }
                Array.Clear(tempArray);
                }
                 
            }
            sr.Close();
    }


    public List<int> setDraws(){
        string line = "";
        string appendedLine = "";
        List<int> drawList = new List<int>();
        
        while((line = sr.ReadLine()) != ""){
            appendedLine += line;
        }

        
        int[] drawArray = appendedLine.Split(',').Select(int.Parse).ToArray();

        foreach(int num in drawArray){
            drawList.Add(num);
        }
        return drawList;
    }


}