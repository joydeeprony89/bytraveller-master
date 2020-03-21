namespace ByTravellerUI.Utilities
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;

    public static class ImageUtility
    {
        public static bool ValidateImageName(IFormFile formFile)
        {
            var isImageValid = false;
            try
            {
                if (formFile != null)
                {
                    var isFileNameValid = !string.IsNullOrWhiteSpace(Path.GetFileNameWithoutExtension(formFile.FileName));
                    var isFileExtValid = !string.IsNullOrWhiteSpace(Path.GetExtension(formFile.FileName));
                    if (isFileNameValid && isFileExtValid)
                    {
                        isImageValid = true;
                    }
                }
            }
            catch (Exception)
            {

                isImageValid = false;
            }

            return isImageValid;
        }
    }
}
