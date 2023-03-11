namespace MeowLab.Utils
{
    public static class IndexLoop
    {
        public static int Next(int current, int length) => ++current < length ? current : 0;
        public static int Prev(int current, int length) => --current < 0 ? length - 1 : current;


        public static int Next(int current, int count, int length) {
            var index = current;
            for (var i = 0; i < count; i++) {
                index = Next(index, length);
            }

            return index;
        }


        public static int Prev(int current, int count, int length) {
            var index = current;
            for (var i = 0; i < count; i++) {
                index = Prev(index, length);
            }

            return index;
        }


        public static int MoveCircular(int current, int offset, int length) {
            if (offset > 0) {
                return Next(current, offset, length);
            }

            if (offset < 0) {
                return Prev(current, offset, length);
            }

            return current;
        }


        //
        // public class IndexLoop
        // {
        //     public int Length { get; private set; }
        //     public int Index { get; private set; }
        //
        //
        //     public IndexLoop(int length)
        //     {
        //         Length = length;
        //     }
        //
        //
        //     public bool Next(out int index)
        //     {
        //         Index = NextLoop(Index, Length);
        //         index = Index;
        //         return true;
        //     }
        //
        //
        //     public int Next()
        //     {
        //         Index = NextLoop(Index, Length);
        //         return Index;
        //     }
        //
        //
        //     public bool Prev(out int index)
        //     {
        //         Index = PrevLoop(Index, Length);
        //         index = Index;
        //         return true;
        //     }
        //
        //
        //     public bool AttemptSetIndex(int index)
        //     {
        //         if (index < Length)
        //         {
        //             Index = index;
        //             return true;
        //         }
        //         else
        //         {
        //             return false;
        //         }
        //     }
        // }
    }
}