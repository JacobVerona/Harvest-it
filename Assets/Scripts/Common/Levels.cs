public static class Levels
{
    public static readonly Level[] GetAll = new Level[]
    {
        new Level(
            new char[,] 
            {
                { 'g','g','g', },
                { 'g','w','g', },
                { 'g','w','g', },
                { 'p','g','g', }
            }),

        new Level(
            new char[,]
            {
                { 'g','g','g','w','g', },
                { 'g','w','g','w','g', },
                { 'g','w','g','w','g', },
                { 'g','w','g','w','g', },
                { 'p','w','g','g','g', },
            }),

        new Level(
             new char[,] 
             {
                { 'w','w','g','g','g', },
                { 'w','w','g','w','w', },
                { 'g','g','g','g','g', },
                { 'g','w','g','w','g', },
                { 'p','w','g','g','g', },
             }),

       new Level(
            new char[,] 
            {
                { 'w','w','w','w','w','g','g', },
                { 'g','g','g','g','g','g','g', },
                { 'g','w','w','w','g','g','g', },
                { 'g','w','w','w','g','g','g', },
                { 'g','g','g','g','g','g','g', },
                { 'w','w','w','w','g','g','w', },
                { 'g','g','g','w','g','g','g', },
                { 'p','w','g','g','g','g','g', },
            }),

        new Level(
            new char[,]
            {
                { 'g','g','g','w','g','g','g', },
                { 'g','w','g','w','g','w','g', },
                { 'g','g','g','g','g','g','g', },
                { 'w','w','g','w','g','w','w', },
                { 'w','w','g','w','g','w','w', },
                { 'g','g','g','g','g','g','g', },
                { 'g','w','g','w','g','w','g', },
                { 'p','w','g','g','g','g','g', },
            }),

         new Level(
             new char[,] 
             {
                 { 'w','g','g','g','g', },
                 { 'g','g','g','g','g', },
                 { 'g','g','w','g','g', },
                 { 'g','g','g','g','g', },
                 { 'p','g','g','g','w', },
             }),

         new Level(
             new char[,]
             {
                { 'g','g','g','g','g','w','w','w', },
                { 'g','w','w','w','w','w','w','w', },
                { 'g','g','g','g','g','g','g','g', },
                { 'g','g','w','w','w','w','w','g', },
                { 'g','g','w','g','g','g','w','g', },
                { 'g','g','g','g','g','g','w','g', },
                { 'w','g','w','g','w','w','w','g', },
                { 'w','p','w','g','g','g','g','g', },
             }),
    };
}