﻿using GeziRehberim.DtoLayer.Dtos.AppUserDtos;
using GeziRehberim.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace GeziRehberim.PresentationLayer.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
		[HttpGet]
        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
		{
			if (ModelState.IsValid)
			{
				Random random = new Random();
				int code;
				code = random.Next(10000, 1000000);
				AppUser appUser = new AppUser()
				{
					UserName=appUserRegisterDto.Username,
					Name=appUserRegisterDto.Name,
					Surname=appUserRegisterDto.Surname,
					Email=appUserRegisterDto.Email,
					City="aaa",
					District="bbb",
					ImageUrl="ccc",
					ConfirmCode=code
				};
				var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);
				if (result.Succeeded)
				{
					MimeMessage mimeMessage = new MimeMessage();
					MailboxAddress mailboxAddressFrom = new MailboxAddress("Gezi Rehberim Admin","mustafacok06@gmail.com");
					MailboxAddress mailboxAddressTo = new MailboxAddress("User",appUser.Email);

					mimeMessage.From.Add(mailboxAddressFrom);
					mimeMessage.To.Add(mailboxAddressTo);

					var bodyBuilder = new BodyBuilder();
					bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz: " + code;
					mimeMessage.Body=bodyBuilder.ToMessageBody();
					mimeMessage.Subject = "Gezi Rehberim Onay Kodu";

					SmtpClient client=new SmtpClient();
					client.Connect("smtp.gmail.com", 587, false);
					client.Authenticate("mustafacok06@gmail.com", "zbgkfwynckfapidh");
					client.Send(mimeMessage);
					client.Disconnect(true);

					TempData["Mail"] = appUserRegisterDto.Email;
					return RedirectToAction("Index","ConfirmMail");

				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View();
		}
	}
}

