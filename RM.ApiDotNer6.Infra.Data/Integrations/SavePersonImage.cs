using RM.ApiDotNet6.Domain.Integrations;

namespace RM.ApiDotNer6.Infra.Data.Integrations
{
    public class SavePersonImage : ISavePersonImage
    {
        private readonly string _filePath;

        public SavePersonImage()
        {
            _filePath = "/Users/ryan.menezes/Downloads/Uploads";
        }

        public string Save(string base64)
        {
            var fileExt = base64.Substring(base64.IndexOf("/") + 1, base64.IndexOf(";") - base64.IndexOf("/") - 1);

            var base64Code = base64.Substring(base64.IndexOf(",") + 1);
            var imgBytes = Convert.FromBase64String(base64Code);

            var fileName = Guid.NewGuid().ToString() + "." + fileExt;
            var path = _filePath + "/" + fileName;

            using (var imageFile = new FileStream(path, FileMode.Create))
            {
                imageFile.Write(imgBytes, 0, imgBytes.Length);
                imageFile.Flush();
            }

            return path;
        }
    }
}
