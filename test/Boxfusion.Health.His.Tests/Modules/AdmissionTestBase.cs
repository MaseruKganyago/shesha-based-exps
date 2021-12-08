using Abp.Domain.Repositories;
using Shesha.Authorization.Users;
using Shesha.Domain;
using System;
using Xunit.Abstractions;

namespace Boxfusion.Health.His.Tests.Modules
{
    public class AdmissionTestBase : SheshaNhTestBase<SeparationsTestModule>
    {
        protected readonly IRepository<Person, Guid> PersonRepo;
        private readonly IRepository<User, Int64> _userRepo;
        private readonly IRepository<ShaRole, Guid> _roleRepo;
        //protected readonly IRepository<WorkOrderType, Guid> WorkOrderTypeRepo;
        //private readonly IWorkflowHelper _workflowHelper;
        protected readonly ITestOutputHelper TestOutputHelper;

        protected AdmissionTestBase(ITestOutputHelper testOutputHelper)
        {
            TestOutputHelper = testOutputHelper;

            // WorkOrderTypeRepo = Resolve<IRepository<WorkOrderType, Guid>>();
            PersonRepo = Resolve<IRepository<Person, Guid>>();
            _userRepo = Resolve<IRepository<User, Int64>>();
            _roleRepo = Resolve<IRepository<ShaRole, Guid>>();
            // _workflowHelper = Resolve<IWorkflowHelper>();
        }

        /// <summary>
        /// Run user task
        /// </summary>
        /// <typeparam name="TResponse">Type of response</typeparam>
        /// <param name="workflowId">Id of the workflow</param>
        /// <param name="actor">Workflow actor</param>
        /// <param name="actionRunner">Task runner. Note: response is pre-filled just with todo id and standard comment</param>
        /// <returns></returns>
        //protected async Task RunUserTask<TResponse>(Guid workflowId, WorkflowActor actor, Func<TResponse, Task> actionRunner) where TResponse : WorkflowActionInput
        //{
        //    // Task VerifyWorkOrder(VerifyWorkOrderInput input);
        //    var todoId = await GetTodoItemId(workflowId, actor);

        //    TestOutputHelper.WriteLine($"RunUserTask: workflowId={workflowId} actor={actor.Username} todoId={todoId}");

        //    Assert.NotNull(todoId);

        //    LoginAsHost(actor.Username);
        //    var response = Activator.CreateInstance<TResponse>();

        //    response.TodoItemId = todoId.Value;
        //    response.Comments = $"Comment from {actor.Username}, todo: {todoId}";

        //    await actionRunner(response);
        //}

        /// <summary>
        /// Prepare workflow actor: ensure we have an account with the specified username and save Id of the user
        /// </summary>
        /// <returns></returns>
        //protected async Task<WorkflowActor> PrepareWorkflowActor(string username, string roleName = null)
        //{
        //    var actor = new WorkflowActor
        //    {
        //        Username = username
        //    };

        //    await WithUnitOfWorkAsync(async () =>
        //    {
        //        // search for user
        //        var user = await _userRepo.GetAll().Where(u => u.UserName == username).FirstOrDefaultAsync();
        //        if (user == null)
        //        {
        //            // register user automatically
        //            user = new User()
        //            {
        //                UserName = username,
        //                EmailAddress = $"{username}@{username}.com",
        //                IsActive = true,
        //                IsEmailConfirmed = true,
        //                IsLockoutEnabled = false,
        //                Name = username,
        //                NormalizedEmailAddress = $"{username}@{username}.com".ToUpper(),
        //                NormalizedUserName = username.ToUpper(),
        //                Surname = username,
        //                Password = "AQAAAAEAACcQAAAAEAksHxNpBNTIMmO6tcuo+LXmH3c34V4tg/4l/broz3JtrZdW+jHc7TrpRQm2RLDs8w=="
        //            };

        //            await _userRepo.InsertOrUpdateAsync(user);
        //        }

        //        // search for Person
        //        var person = await PersonRepo.GetAll().FirstOrDefaultAsync(p => p.User == user);
        //        if (person == null)
        //        {
        //            person = new Person
        //            {
        //                FirstName = user.Name,
        //                LastName = user.Surname,
        //                EmailAddress1 = user.EmailAddress,
        //                User = user
        //            };
        //            await PersonRepo.InsertAsync(person);
        //        }

        //        actor.PersonId = person.Id;

        //        // add to role if needed
        //        if (!string.IsNullOrWhiteSpace(roleName))
        //        {
        //            var role = await _roleRepo.GetAll().FirstOrDefaultAsync(r => r.Name == roleName);
        //            if (role == null)
        //                throw new Exception($"Role `{roleName}` not found");

        //            var roleAppointmentRepo = Resolve<IRepository<ShaRoleAppointedPerson, Guid>>();
        //            var isInRole = await roleAppointmentRepo.GetAll().AnyAsync(a => a.Role == role && a.Person == person);
        //            if (!isInRole)
        //            {
        //                var appointment = new ShaRoleAppointedPerson
        //                {
        //                    Role = role,
        //                    Person = person
        //                };
        //                await roleAppointmentRepo.InsertAsync(appointment);
        //            }
        //        }
        //    });

        //    return actor;
        //}

        /// <summary>
        /// Returns Id of the todoItem for the specified <paramref name="actor"/> in the workflow with id = <paramref name="workflowId"/>
        /// </summary>
        //protected async Task<Guid?> GetTodoItemId(Guid? workflowId, WorkflowActor actor)
        //{
        //    Guid? todoItemId = null;
        //    await WithUnitOfWorkAsync(async () =>
        //    {
        //        var todoItems = await _workflowHelper.GetTodoItemsAsync(workflowId.Value, actor.PersonId);
        //        todoItemId = todoItems.FirstOrDefault()?.Id;
        //    });

        //    return todoItemId;
        //}
    }
}
