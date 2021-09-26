namespace LTCPool_UTSharp
{
    public enum HashScales : ulong  //Backing type is ulong
    {
        //Here we assign each value it's size
        //so that if we convert HashScales to a number
        //it will return the proper scale
        //Ex. ulong N = (ulong)HashScales.MH
        //N is 1 million
        H = 1,
        KH = 1_000,
        MH = 1_000_000,
        GH = 1_000_000_000,
        TH = 1_000_000_000_000,
    }
}
