using System.Collections.Generic;

namespace DAL.A_DTO
{
    public class FileDTO
    {
        public decimal FileId { get; set; }
        public string TypeFile { get; set; }
        public string DescriptionFile { get; set; }
        public string SrcDrivFile { get; set; }
        public string SrcPdfFile { get; set; }
        public decimal? LessonId { get; set; }
        public List<DocumentDto> Document { get; set; }
    }
}