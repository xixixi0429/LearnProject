using LearnRecordAPI.Data;
using LearnRecordAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Web.Http;
using static LearnRecordAPI.Models.DTO.learnSubtopicAdminDTO;
using static LearnRecordAPI.Models.DTO.learnTopicAdminDTO;

namespace LearnRecordAPI.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class LearnTopicController : ControllerBase
    {
        private readonly LearnRecordDBContext _context;

        public LearnTopicController(LearnRecordDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 查詢大類別
        /// </summary>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("GetLearnTopicAdmin")]
        public async Task<IActionResult> GetLearnTopicAdmin()
        {
            var result = await _context.learnTopicAdmin
                .OrderBy(x => x.order)
                .ToListAsync();

            return Ok(result);
        }

        /// <summary>
        /// 查詢全類別
        /// </summary>
        /// <param name="topicName"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("GetLearnAllTopicAdmin")]
        public async Task<IActionResult> GetLearnAllTopicAdmin()
        {
            var topics = await _context.learnTopicAdmin
                .Select(topic => new
                {
                    topic.topicID,
                    topic.topicName,
                    topic.order,
                    topic.description,
                    subtopics = _context.learnSubtopicAdmin
                        .Where(subtopic => subtopic.topicID == topic.topicID)
                        .ToList()
                })
                .OrderBy(topic => topic.order)
                .ToListAsync();

            var result = topics.Select(topic => new
            {
                topic.topicID,
                topic.topicName,
                topic.order,
                topic.description,
                subtopicCount = topic.subtopics.Count(),
                subtopicDetail = topic.subtopics.Select(subtopic => new
                {
                    subtopic.subtopicID,
                    subtopic.subtopicName,
                    subtopic.description,
                    subtopic.order
                }).ToList()
            }).ToList();

            return Ok(result);
        }

        /// <summary>
        /// 查詢小類別
        /// </summary>
        /// <param name="topicName"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("GetLearnSubtopicAdmin/{topicName}")]
        public async Task<IActionResult> GetLearnSubtopicAdmin(string topicName)
        {
            var topics = await _context.learnTopicAdmin
                .Where(x => x.topicName == topicName)
                .Select(topic => new
                {
                    topic.topicID,
                    topic.topicName,
                    subtopics = _context.learnSubtopicAdmin
                        .Where(subtopic => subtopic.topicID == topic.topicID)
                        .ToList()
                })
                .ToListAsync();

            var result = topics.Select(topic => new
            {
                topic.topicID,
                topic.topicName,
                subtopicCount = topic.subtopics.Count(),
                subtopicDetail = topic.subtopics.Select(subtopic => new
                {
                    subtopic.subtopicID,
                    subtopic.subtopicName,
                    subtopic.description,
                    subtopic.order
                }).ToList()
            }).ToList();

            return Ok(result);
        }

        /// <summary>
        /// 新增大類別
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpPost("AddLearnTopic")]
        public async Task<IActionResult> AddLearnTopic([System.Web.Http.FromBody] learnTopicAdminAdd data)
        {
            var insertData = new learnTopicAdmin
            {
                topicID = Guid.NewGuid(),
                topicName = data.topicName,
                function = data.function,
                order = data.order,
                description = data.description,
                creator = data.creator,
                createTime = DateTime.Now,
                updater = null,
                updateTime = null
            };

            _context.learnTopicAdmin.Add(insertData);
            await _context.SaveChangesAsync();

            return Ok(insertData);
        }

        /// <summary>
        /// 修改大類別
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpPut("UpdateLearnTopic")]
        public async Task<IActionResult> UpdateLearnTopic([System.Web.Http.FromBody] learnTopicAdminUpdate data)
        {
            var modifyData = await _context.learnTopicAdmin.FirstOrDefaultAsync(x => x.topicID == data.topicID);

            modifyData.topicName = data.topicName;
            modifyData.function = data.function;
            modifyData.order = data.order;
            modifyData.description = data.description;
            modifyData.updater = data.updater;
            modifyData.updateTime = DateTime.Now;

            _context.Entry(modifyData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(modifyData);
        }

        /// <summary>
        /// 刪除大類別
        /// </summary>
        /// <param name="topicID"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete("DeleteLearnTopic/{topicID}")]
        public async Task<IActionResult> DeleteLearnTopic(Guid topicID)
        {
            //刪除大項
            var deleteData = await _context.learnTopicAdmin
                .Where(x => x.topicID == topicID)
                .FirstOrDefaultAsync();
            if (deleteData != null)
            {
                _context.learnTopicAdmin.Remove(deleteData);
                await _context.SaveChangesAsync();
            }

            //刪除小項
            var deleteData2 = await _context.learnSubtopicAdmin
                .Where(x => x.topicID == topicID)
                .FirstOrDefaultAsync();
            if (deleteData2 != null)
            {
                _context.learnSubtopicAdmin.Remove(deleteData2);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        /// <summary>
        /// 新增小類別
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpPost("AddLearnSubtopic")]
        public async Task<IActionResult> AddLearnSubtopic([System.Web.Http.FromBody] learnSubtopicAdminAdd data)
        {
            var insertData = new learnSubtopicAdmin
            {
                topicID = data.topicID,
                subtopicID = Guid.NewGuid(),
                subtopicName = data.subtopicName,
                order = data.order,
                description = data.description,
                creator = data.creator,
                createTime = DateTime.Now,
                updater = null,
                updateTime = null
            };

            _context.learnSubtopicAdmin.Add(insertData);
            await _context.SaveChangesAsync();

            return Ok(insertData);
        }

        /// <summary>
        /// 修改小類別
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpPut("UpdateLearnSubtopic")]
        public async Task<IActionResult> UpdateLearnSubtopic([System.Web.Http.FromBody] learnSubtopicAdminUpdate data)
        {
            var modifyData = await _context.learnSubtopicAdmin.FirstOrDefaultAsync(x => x.topicID == data.topicID && x.subtopicID == data.subtopicID);

            modifyData.subtopicName = data.subtopicName;
            modifyData.order = data.order;
            modifyData.description = data.description;
            modifyData.updater = data.updater;
            modifyData.updateTime = DateTime.Now;

            _context.Entry(modifyData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(modifyData);
        }

        /// <summary>
        /// 刪除小類別
        /// </summary>
        /// <param name="subtopicID"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete("DeleteLearnSubtopic/{subtopicID}")]
        public async Task<IActionResult> DeleteLearnSubtopic(Guid subtopicID)
        {
            //刪除小項
            var deleteData = await _context.learnSubtopicAdmin
                .Where(x => x.subtopicID == subtopicID)
                .FirstOrDefaultAsync();
            if (deleteData != null)
            {
                _context.learnSubtopicAdmin.Remove(deleteData);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
