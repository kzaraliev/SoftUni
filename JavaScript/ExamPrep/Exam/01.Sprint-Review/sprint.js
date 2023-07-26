function sprintReview(input) {
  const n = Number(input.shift());
  const assigneesTickets = input.slice(0, n);
  const commands = input.slice(n);

  const board = assigneesTickets.reduce((acc, curr) => {
    const [assignee, taskId, title, status, points] = curr.split(":");

    if (!acc.hasOwnProperty(assignee)) {
      acc[assignee] = [];
    }

    acc[assignee].push({ taskId, title, status, points: Number(points) });

    return acc;
  }, {});

  const commandExecutor = {
    "Add New": addNewTask,
    "Change Status": changeTaskStatus,
    "Remove Task": removeTask,
  };

  commands.forEach((command) => {
    const [commandName, ...rest] = command.split(":");
    commandExecutor[commandName](...rest);
  });

  const todoPoints = caclulateTotalForStatus("ToDo");
  const inProgressPoints = caclulateTotalForStatus("In Progress");
  const reviewPoints = caclulateTotalForStatus("Code Review");
  const donePoints = caclulateTotalForStatus("Done");

  console.log(`ToDo: ${todoPoints}pts`);
  console.log(`In Progress: ${inProgressPoints}pts`);
  console.log(`Code Review: ${reviewPoints}pts`);
  console.log(`Done Points: ${donePoints}pts`);

  if (donePoints >= todoPoints + inProgressPoints + reviewPoints) {
    console.log("Sprint was successful!");
  } else {
    console.log("Sprint was unsuccessful...");
  }

  function addNewTask(assignee, taskId, title, status, points) {
    if (!board.hasOwnProperty(assignee)) {
      console.log(`Assignee ${assignee} does not exist on the board!`);
      return;
    }

    board[assignee].push({ taskId, title, status, points: Number(points) });
  }

  function changeTaskStatus(assignee, taskId, status) {
    if (!board.hasOwnProperty(assignee)) {
      console.log(`Assignee ${assignee} does not exist on the board!`);
      return;
    }

    const task = board[assignee].find((t) => t.taskId === taskId);

    if (!task) {
      console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
      return;
    }

    task.status = status;
  }

  function removeTask(assignee, index) {
    if (!board.hasOwnProperty(assignee)) {
      console.log(`Assignee ${assignee} does not exist on the board!`);
      return;
    }

    if (index < 0 || index >= board[assignee].length) {
      console.log("Index is out of range!");
      return;
    }

    board[assignee].splice(index, 1);
  }

  function caclulateTotalForStatus(status) {
    return Object.values(board)
      .flat()
      .filter((t) => t.status === status)
      .reduce((acc, curr) => {
        return acc + curr.points;
      }, 0);
  }
}

sprintReview([
  "5",
  "Kiril:BOP-1209:Fix Minor Bug:ToDo:3",
  "Mariya:BOP-1210:Fix Major Bug:In Progress:3",
  "Peter:BOP-1211:POC:Code Review:5",
  "Georgi:BOP-1212:Investigation Task:Done:2",
  "Mariya:BOP-1213:New Account Page:In Progress:13",
  "Add New:Kiril:BOP-1217:Add Info Page:In Progress:5",
  "Change Status:Peter:BOP1290:ToDo",
  "Remove Task:Mariya:1",
  "Remove Task:Joro:1",
]);
