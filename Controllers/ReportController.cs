using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebsiteHotelManagerment.Models;

[Authorize(Roles = "Admin")]
public class ReportController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReportController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult PaymentStats(string type = "month", DateTime? startDate = null, DateTime? endDate = null)
    {
        var orders = _context.Orders
            .Where(o => o.TrangThai == TrangThaiDonHang.DaThanhCong)
            .ToList();

        // Lọc theo khoảng thời gian nếu có
        if (startDate.HasValue)
            orders = orders.Where(o => o.CreatedAt >= startDate).ToList();

        if (endDate.HasValue)
            orders = orders.Where(o => o.CreatedAt <= endDate).ToList();

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
        else if (type == "week")
        {
            var byWeek = orders
                .GroupBy(o => new
                {
                    Year = o.CreatedAt?.Year ?? 0,
                    Week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                        o.CreatedAt ?? DateTime.MinValue,
                        CalendarWeekRule.FirstFourDayWeek,
                        DayOfWeek.Monday)
                })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Week)
                .ToList();

            foreach (var group in byWeek)
            {
                labels.Add($"Tuần {group.Key.Week}/{group.Key.Year}");
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

        // Danh sách loại báo cáo
        var types = new List<SelectListItem>
        {
            new SelectListItem { Value = "day", Text = "Theo ngày" },
            new SelectListItem { Value = "week", Text = "Theo tuần" },
            new SelectListItem { Value = "month", Text = "Theo tháng" },
            new SelectListItem { Value = "year", Text = "Theo năm" }
        };

        ViewBag.TypeList = new SelectList(types, "Value", "Text", type);
        ViewBag.Labels = labels.ToArray();
        ViewBag.Totals = totals.ToArray();
        ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
        ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");

        return View();
    }
}
