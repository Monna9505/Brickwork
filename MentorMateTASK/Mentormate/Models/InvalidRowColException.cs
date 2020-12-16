using System;
using System.Collections.Generic;
using System.Text;

namespace Brickwork
{
    public static class InvalidRowColException
    {
        private const string INVALID_COLUMNS = "Rows and cols should be between the size of 1 - 100";

        public static void Validate(int nm)
        {
            if (!(nm >= 1 && nm <= 100))
            {
                throw new IndexOutOfRangeException(INVALID_COLUMNS);
            }
        }
    }
}
