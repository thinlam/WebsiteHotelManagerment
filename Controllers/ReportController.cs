using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteHotelManagerment.Models;

public class ReportController : Controller
{
    private readonly ApplicationDbContext _context;
    public ReportController(ApplicationDbContext context)
    {
        _context = context;
    }
    [Authorize(Roles = "Admin")]
    public IActionResult PaymentStats(string type = "month")
    {
        var orders = _context.Orders
            .Where(o => o.TrangThai == TrangThaiDonHang.DaThanhCong)
            .ToList();

        List<string> labels = new();
        List<decimal> totals = new();

        if (type == "day")
        {
            var byDay = orders
                .GroupBy(o => o.CreatedAt?.Date ?? DateTime.MinValue)
                .OrderBy(g => g.Key)
                .ToList();

            foreach (var group in byDay)
            {
                labels.Add(group.Key.ToString("dd/MM/yyyy"));
                totals.Add(group.Sum(o => o.TongTien));
            }
        }
        else if (type == "month")
        {
            var byMonth = orders
                .GroupBy(o => new { Year = o.CreatedAt?.Year ?? 0, Month = o.CreatedAt?.Month ?? 0 })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .ToList();

            foreach (var group in byMonth)
            {
                labels.Add($"Tháng {group.Key.Month}/{group.Key.Year}");
                totals.Add(group.Sum(o => o.TongTien));
            }
        }
        else if (type == "year")
        {
            var byYear = orders
                .GroupBy(o => o.CreatedAt?.Year ?? 0)
                .OrderBy(g => g.Key)
                .ToList();

            foreach (var group in byYear)
            {
                labels.Add($"Năm {group.Key}");
                totals.Add(group.Sum(o => o.TongTien));
            }
        }

        // Tạo SelectList để chọn trong dropdown, đánh dấu selected chuẩn
        var types = new List<SelectListItem>
        {
            new SelectListItem { Value = "day", Text = "Theo ngày" },
            new SelectListItem { Value = "month", Text = "Theo tháng" },
            new SelectListItem { Value = "year", Text = "Theo năm" }
        };
        ViewBag.TypeList = new SelectList(types, "Value", "Text", type);

        ViewBag.Labels = labels.ToArray();
        ViewBag.Totals = totals.ToArray();

        return View();
    }
}
