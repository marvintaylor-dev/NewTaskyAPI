﻿using NewTaskyAPI.Shared;
using NewTaskyAPI.Shared.DTOs;

namespace NewTaskyAPI.Server.Data.TaskRepository
{
    public interface ITaskRepository
    {
        Task<List<NoteModel>> GetAllTasks();
        Task<List<NoteModel>> GetAllTasksInOrder();
        Task<List<NoteModel>> GetAllSubtasks();
        Task<List<NoteModel>> GetAllSubtasksByParentId(int parentId);
        Task<NoteModel> GetTaskById(int id);
        Task<NoteModel> AddTask(NoteModel model);
        Task<List<NoteModel>> AddMultipleTasks(List<NoteModel> tasks);
        Task<NoteModel> UpdateTask(NoteModel model);
        Task<NoteModel> DeleteTask(int id);
    }
}
