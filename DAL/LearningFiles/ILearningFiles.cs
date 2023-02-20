using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.A_DTO;

namespace DAL.LearningFiles
{
    public interface ILearningFiles
    {
        public Task<bool> addLearningFileDAL(FileDTO learningFile);
        public Task<bool> UpdateLearningFilesDAL(LearningFile learningFile);
        public Task<bool> DeleteFileDAL(decimal FileID);
        public Task<LearningFile> getLearningFileAccordingToIDDAL(decimal LearningFileID);
        public Task<List<LearningFile>> getListLearningFilesAccordingToPreparedLessonIDDAL(decimal PreparedLessonID);
    }
}
