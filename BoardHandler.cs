class BoardHandler{

    List<Board> boards;
    Draws draws;
    StreamReader sr = new StreamReader(@"C:\Users\12152\Documents\Projects\csharp\Bingo\input.txt");

    public BoardHandler(){
        boards = new List<Board>();
        draws = new Draws(setDraws());
        setBoards();
    }

    public void gameLoop(){

    }

    public void setBoards(){
        string line = "";
        List<int> boardNums = new List<int>();
        int[] tempArray;

            while((line = sr.ReadLine()) != null)
            {

                if(line == ""){
                 boards.Add(new Board(boardNums));
                } else {

                 tempArray = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                 foreach(int num in tempArray){
                    boardNums.Add(num);
                }
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