using DayanShop.Utilities.DTOs;

namespace DayanShop.Utilities.Helpers;

public static class DeleteFile
{

    public static ResultDto DeleteFileFromRoot(string path)
    {
        System.IO.File.Delete(path);
        return new ResultDto()
        {
            IsSuccess = true,
            Message = "doun"
        };
    }
}