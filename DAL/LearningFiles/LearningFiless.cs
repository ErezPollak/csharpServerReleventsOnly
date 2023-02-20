using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.A_DTO;

namespace DAL.LearningFiles
{
    public class LearningFiless : ILearningFiles
    {
        private My_Virtua_lSchoolContext _context;
        private readonly IMapper _mapper;
        public LearningFiless(My_Virtua_lSchoolContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public LearningFiless()
        {

        }

        public async Task<bool> addLearningFileDAL(FileDTO learningFile)
        {
            decimal max = 0;
            if (_context.LearningFile.Count() != 0)
            {
               max =_context.LearningFile.Max(lesson => lesson.FileId);
            }
            
            
            var FileModel = _mapper.Map<LearningFile>(learningFile);
            FileModel.SrcPdfFile = learningFile.Document != null ? learningFile.Document[0].file : null;
            FileModel.FileId = max + 1;
            var resLearningFile = await _context.LearningFile.AddAsync(FileModel);
            try
            {

                var x=await _context.SaveChangesAsync()>=0;
                if(x==true)
                {

                }
            }catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteFileDAL(decimal FileID)
        {
            try
            {
                var resLearningFiles = await _context.LearningFile.Where(x => x.FileId.Equals(FileID)).FirstOrDefaultAsync();
                var resTeacherEnd = _context.LearningFile.Remove(resLearningFiles);
                var isOk = await _context.SaveChangesAsync() >= 0;
                if (isOk)
                {
                }
                else
                {
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

       

        public async Task<LearningFile> getLearningFileAccordingToIDDAL(decimal LearningFileID)
        {
            var resLearningFile = await _context.LearningFile.Where(x => x.FileId == LearningFileID).FirstOrDefaultAsync();
            if (resLearningFile != null)
            {
                return resLearningFile;
            }
            return null;
        }

        public async Task<List<LearningFile>> getListLearningFilesAccordingToPreparedLessonIDDAL(decimal LearningFileID)
        {
           return await _context.LearningFile.Where(x => x.LessonId == LearningFileID).Select(x => x).ToListAsync();
        
        }

        public async Task<bool> UpdateLearningFilesDAL(LearningFile learningFile)
        {
            try
            {
                var resLearningFiles = await _context.LearningFile.Where(x => x.FileId.Equals(learningFile.FileId)).FirstOrDefaultAsync();
                resLearningFiles.Lesson = learningFile.Lesson;
                resLearningFiles.TypeFile = learningFile.TypeFile;
                resLearningFiles.DescriptionFile = learningFile.DescriptionFile;
                resLearningFiles.SrcDrivFile = learningFile.SrcDrivFile;
                resLearningFiles.SrcPdfFile = learningFile.SrcPdfFile;
                //var resTeacherEnd = _context.LearningFile.AddAsync(resLearningFiles);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
