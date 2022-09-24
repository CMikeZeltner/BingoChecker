class Draws{
    List<int> draws;

    public Draws(List<int> nums){
        draws = nums;
    }

    public int drawNumber(){
        int returnDraw = draws[0];
        draws.RemoveAt(0);
        return returnDraw;
    }

    public void print(){
        foreach(int num in draws){
            System.Console.WriteLine(num);
        }
    }
}