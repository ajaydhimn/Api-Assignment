using ApiAssignment.ServiceModel;
using ServiceStack;
using System;
using System.Linq;

namespace ApiAssignment.ServiceInterface
{
    public class BinaryService : Service
    {
        //Method will throw exception if Binary is Invalid otherwise it will return 204
        public void Post(BinaryValidationRequest request)
        {
            var binaryCharArray = request.Binary.ToCharArray();

            if (binaryCharArray.Any(x => x != '0' && x != '1'))
            {
                throw new Exception("Invalid Binary: String contains invalid characters i.e. other than 0 and 1");
            }
            if (binaryCharArray.Where(x => x != '0').Count() != binaryCharArray.Where(x => x != '1').Count())
            {
                throw new Exception("Invalid Binary: Number of 0's not equal to number of 1's");
            }
            for (int i = 1; i <= binaryCharArray.Count(); i++)
            {
                var prefixBinary = binaryCharArray.Take(i);
                if (prefixBinary.Where(x => x == '1').Count() < prefixBinary.Where(x => x == '0').Count())
                {
                    throw new Exception("Invalid Binary: Number of 1's is less than the number of 0's in prefix");
                }
            }
        }
    }
}