﻿using RoadReady.Models;
using RoadReady.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using RoadReady.Exceptions;

namespace RoadReady.Controllers
{
    [EnableCors("Policy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        //[AllowAnonymous]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogInformation("Fetching all users");
                List<User> users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (UserNotFoundException)
            {
                _logger.LogError("Error occurred while fetching all users");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("user/id/{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                _logger.LogInformation("Fetching user with ID: {Id}", id);
                User user = _userService.GetUserById(id);
                if (user == null)
                {
                    _logger.LogWarning($"User with ID: {id} not found", id);
                    return NotFound();
                }
                return Ok(user);
            }
            catch (UserNotFoundException)
            {
                _logger.LogError($"Error occurred while fetching user with ID: {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("user/userName/{userName}")]
        public IActionResult GetUserByUserName(string userName)
        {
            try
            {
                _logger.LogInformation($"Fetching user with name: {userName}", userName);
                User user = _userService.GetUserByUserName(userName);
                if (user == null)
                {
                    _logger.LogWarning($"User with userName: {userName} not found", userName);
                    return NotFound();
                }
                return Ok(user);
            }
            catch (UserNotFoundException)
            {
                _logger.LogError($"Error occurred while fetching user with userName: {userName}", userName);
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(User user)
        {
            try
            {
                _logger.LogInformation("Creating new user.");
                int result = _userService.AddUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = result }, user);
            }
            catch (Exception)
            {
                _logger.LogError("Error occurred while creating a new user");
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult Put(User user)
        {
            try
            {
                _logger.LogInformation("Updating the user ");
                string result = _userService.UpdateUser(user);
                if (result == null)
                {
                    _logger.LogWarning("User not found");
                    return NotFound("User not found.");
                }
                return Ok(result);
            }
            catch (UserNotFoundException)
            {
                return NotFound("User not found.");
            }
            catch (Exception)
            {
                _logger.LogError("Error occurred while updating user");
                return StatusCode(500, "Internal server error");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting user with ID: {id}", id);
                string result = _userService.DeleteUser(id);
                if (result==null)
                {
                    _logger.LogWarning($"User with ID: {id} not found", id);
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                _logger.LogError($"Error occurred while deleting user with ID: {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
