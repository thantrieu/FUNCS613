﻿/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.22</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Text;

namespace ExercisesLesson611
{
    class Exercises2
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            BankAccount[] bankAccounts = new BankAccount[100];
            int numOfAccount = 0;
            CreateFakeAccount(bankAccounts, ref numOfAccount);
            int choice;
            do
            {
                Console.WriteLine("================== CÁC CHỨC NĂNG ==================");
                Console.WriteLine("01. Thêm mới tài khoản ngân hàng vào danh sách.");
                Console.WriteLine("02. Hiển thị danh sách tài khoản ra màn hình.");
                Console.WriteLine("03. Sắp xếp danh sách theo số dư giảm dần.");
                Console.WriteLine("04. Nộp tiền vào tài khoản theo số tài khoản.");
                Console.WriteLine("05. Kiểm tra số dư của tài khoản.");
                Console.WriteLine("06. Rút tiền cùng ngân hàng của một tài khoản.");
                Console.WriteLine("07. Rút tiền khác ngân hàng của một tài khoản.");
                Console.WriteLine("08. Chuyển tiền cùng ngân hàng của một tài khoản.");
                Console.WriteLine("09. Chuyển tiền khác ngân hàng của một tài khoản.");
                Console.WriteLine("10. Thanh toán phí dịch vụ cho một tài khoản.");
                Console.WriteLine("11. Chốt lãi cho các tài khoản trong danh sách.");
                Console.WriteLine("12. Thoát chương trình.");
                Console.WriteLine("==> Xin mời bạn chọn chức năng: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        var acc = CreateAccount();
                        if (acc != null)
                        {
                            bankAccounts[numOfAccount++] = acc;
                        }
                        break;
                    case 2:
                        if (numOfAccount > 0)
                        {
                            ShowAccounts(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 3:
                        if (numOfAccount > 0)
                        {
                            SortAccounts(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 4:
                        if (numOfAccount > 0)
                        {
                            Deposit(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 5:
                        if (numOfAccount > 0)
                        {
                            CheckBallance(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 6:
                        if (numOfAccount > 0)
                        {
                            Withdraw(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 7:
                        if (numOfAccount > 0)
                        {
                            WithdrawOtherBank(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 8:
                        if (numOfAccount > 0)
                        {
                            TransferSameBank(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 9:
                        if (numOfAccount > 0)
                        {
                            TransferDifferentBank(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 10:
                        if (numOfAccount > 0)
                        {
                            PayService(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 11:
                        if (numOfAccount > 0)
                        {
                            CalculateInterest(bankAccounts);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách tài khoản rỗng. <==");
                        }
                        break;
                    case 12:
                        Console.WriteLine("==> Cảm ơn quý khách đã sử dụng dịch vụ! <==");
                        break;
                    default:
                        Console.WriteLine("==> Sai chức năng. Vui lòng chọn lại! <==");
                        break;
                }
            } while (choice != 12);
        }

        // tạo tài khoản mới
        private static BankAccount CreateAccount()
        {
            Console.WriteLine("==> Xin mời chọn: ");
            Console.WriteLine("1. Tạo tài khoản Thanh toán.");
            Console.WriteLine("2. Tạo tài khoản Tiết kiệm.");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                Console.WriteLine("Họ và tên chủ tài khoản: ");
                var owner = Console.ReadLine().ToUpper();
                Console.WriteLine("Ngân hàng phát hành: ");
                var bank = Console.ReadLine();
                Console.WriteLine("Tháng năm phát hành(ví dụ 01/21): ");
                var releaseDate = Console.ReadLine();
                Console.WriteLine("Số dư(kđ, 1kđ = 1000đ): ");
                var balance = long.Parse(Console.ReadLine()) * 1000;
                Console.WriteLine("Hạn mức một ngày(kđ, 1kđ = 1000đ): ");
                var limit = long.Parse(Console.ReadLine()) * 1000;
                return new CheckingAccount(null, owner, bank, releaseDate, balance, limit);
            }
            else if (ans == 2)
            {
                Console.WriteLine("Họ và tên chủ tài khoản: ");
                var owner = Console.ReadLine().ToUpper();
                Console.WriteLine("Ngân hàng phát hành: ");
                var bank = Console.ReadLine();
                Console.WriteLine("Tháng năm phát hành(ví dụ 01/21): ");
                var releaseDate = Console.ReadLine();
                Console.WriteLine("Số dư(kđ, 1kđ = 1000đ): ");
                var balance = long.Parse(Console.ReadLine()) * 1000;
                Console.WriteLine("Kỳ hạn(tháng, gửi không thời hạn ghi -1): ");
                var term = int.Parse(Console.ReadLine());
                var startDate = DateTime.Now;
                return new SavingAccount(null, owner, bank, releaseDate,
                    balance, term, startDate, startDate.AddMonths(term));
            }
            return null;
        }

        // tính tiền lãi cuối kỳ của từng tài khoản, cộng gộp vào tk gốc
        private static void CalculateInterest(BankAccount[] bankAccounts)
        {
            for (int i = 0; i < bankAccounts.Length; i++)
            {
                if (bankAccounts[i] == null)
                {
                    break;
                }
                var acc = bankAccounts[i];
                var amount = acc.CalculateInterest();
                acc.Deposit(amount, acc.Bank);
            }
        }

        // trả phí dịch vụ
        private static void PayService(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản cần thanh toán: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            Console.WriteLine("Số tài khoản nhận thanh toán: ");
            var destAccNumber = Console.ReadLine();
            var destAcc = FindAccountByAccNumber(bankAccounts, destAccNumber);
            if (acc != null && destAcc != null)
            {
                Console.WriteLine("Số tiền phải trả(kđ): ");
                var amount = long.Parse(Console.ReadLine()) * 1000;
                var result = acc.Pay(destAcc, amount, acc.Bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Thanh toán thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Thanh toán thất bại. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản nguồn hoặc tài khoản đích không tồn tại. <==");
            }
        }

        // chuyển tiền khác ngân hàng
        private static void TransferDifferentBank(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản nguồn: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            Console.WriteLine("Số tài khoản đích: ");
            var destAccNumber = Console.ReadLine();
            var destAcc = FindAccountByAccNumber(bankAccounts, destAccNumber);
            if (acc != null && destAcc != null)
            {
                Console.WriteLine("Số tiền muốn chuyển(kđ): ");
                var amount = long.Parse(Console.ReadLine()) * 1000;
                Console.WriteLine("Ngân hàng thực hiện: ");
                var bank = Console.ReadLine();
                var result = acc.BankTransfer(destAcc, amount, bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Chuyển tiền thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Chuyển tiền thất bại. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản nguồn hoặc tài khoản đích không tồn tại. <==");
            }
        }

        // chuyển tiền cùng ngân hàng
        private static void TransferSameBank(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản nguồn: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            Console.WriteLine("Số tài khoản đích: ");
            var destAccNumber = Console.ReadLine();
            var destAcc = FindAccountByAccNumber(bankAccounts, destAccNumber);
            if (acc != null && destAcc != null)
            {
                Console.WriteLine("Số tiền muốn chuyển(kđ): ");
                var amount = long.Parse(Console.ReadLine()) * 1000;
                var result = acc.BankTransfer(destAcc, amount, acc.Bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Chuyển tiền thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Chuyển tiền thất bại. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản nguồn hoặc tài khoản đích không tồn tại. <==");
            }
        }

        // rút tiền khác ngân hàng
        private static void WithdrawOtherBank(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            if (acc != null)
            {
                Console.WriteLine("Số tiền muốn rút(kđ): ");
                var amount = long.Parse(Console.ReadLine()) * 1000;
                Console.WriteLine("Ngân hàng thực hiện: ");
                var bank = Console.ReadLine();
                var result = acc.Withdraw(amount, bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Rút tiền thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Rút tiền thất bại. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản cần tìm không tồn tại. <==");
            }
        }

        // rút tiền cùng ngân hàng
        private static void Withdraw(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            if (acc != null)
            {
                Console.WriteLine("Số tiền muốn rút(kđ): ");
                var amount = long.Parse(Console.ReadLine()) * 1000;
                var result = acc.Withdraw(amount, acc.Bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Rút tiền thành công. <==");
                }
                else
                {
                    Console.WriteLine("==> Rút tiền thất bại. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản cần tìm không tồn tại. <==");
            }
        }

        // kiểm tra số dư tài khoản
        private static void CheckBallance(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            Console.WriteLine("Ngân hàng thực hiện: ");
            var bankName = Console.ReadLine();
            if (acc != null)
            {
                acc.CheckBallance(bankName);
            }
            else
            {
                Console.WriteLine("==> Tài khoản cần tìm không tồn tại. <==");
            }
        }

        // tìm tài khoản theo số tài khoản
        public static BankAccount FindAccountByAccNumber(BankAccount[] accounts, string accNumber)
        {
            foreach (var item in accounts)
            {
                if (item != null && item.AccountNumber.CompareTo(accNumber) == 0)
                {
                    return item;
                }
            }
            return null;
        }

        // nạp tiền vào tài khoản
        private static void Deposit(BankAccount[] bankAccounts)
        {
            Console.WriteLine("Số tài khoản: ");
            var accNumber = Console.ReadLine();
            var acc = FindAccountByAccNumber(bankAccounts, accNumber);
            if (acc != null)
            {
                Console.WriteLine("Tên ngân hàng làm dịch vụ: ");
                var bank = Console.ReadLine();
                Console.WriteLine("Số tiền cần gửi vào TK(kđ): ");
                var amount = long.Parse(Console.ReadLine()) * 1000;
                var result = acc.Deposit(amount, bank);
                if (result > 0)
                {
                    Console.WriteLine("==> Giao dịch thành công. <==");
                }
            }
            else
            {
                Console.WriteLine("==> Tài khoản cần tìm không tồn tại. <==");
            }
        }

        // sắp xếp tài khoản theo số dư giảm dần
        private static void SortAccounts(BankAccount[] bankAccounts)
        {
            int comparer(BankAccount a, BankAccount b)
            {
                if (a == null && b == null)
                {
                    return 0;
                }
                else if (a != null && b == null)
                {
                    return -1;
                }
                else if (a == null && b != null)
                {
                    return 1;
                }
                else
                {
                    if (a.Balance > b.Balance)
                    {
                        return -1;
                    }
                    else if (a.Balance < b.Balance)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            Array.Sort(bankAccounts, comparer);
        }

        // hiển thị danh sách tài khoản
        private static void ShowAccounts(BankAccount[] bankAccounts)
        {
            var accNumber = "Số tài khoản";
            var owner = "Chủ tài khoản";
            var bank = "Ngân hàng";
            var releaseDate = "Ngày phát hành";
            var balance = "Số dư";
            var interestRate = "Lãi suất";
            var limit = "Hạn mức";
            var term = "Kỳ hạn";
            var start = "Ngày gửi";
            var end = "Ngày hết hạn";
            var interest = "Tiền lãi";
            Console.WriteLine($"{accNumber,-20:d}{owner,-25:d}{bank,-15:d}{releaseDate,-15:d}" +
                $"{balance,-20:d}{interestRate,-15:d}{limit,-20:d}{term,-15:d}{start,-15:d}" +
                $"{end,-15:d}{interest,-20:d}");
            var noData = "-";
            var noTerm = "Không kỳ hạn";
            var format = "dd/MM/yyyy";
            foreach (var item in bankAccounts)
            {
                if (item == null)
                {
                    break;
                }
                if (item.GetType() == typeof(CheckingAccount))
                {
                    var acc = item as CheckingAccount;
                    Console.WriteLine($"{acc.AccountNumber,-20:d}{acc.Owner,-25:d}{acc.Bank,-15:d}" +
                        $"{acc.ReleaseDate,-15:d}{acc.Balance,-20:n}{acc.InterestRate / 100,-15:p}" +
                        $"{acc.PaymentLimit,-20:n}{noTerm,-15:d}{noData,-15:d}" +
                        $"{noData,-15:d}{acc.CalculateInterest(),-20:n}");
                }
                else if (item.GetType() == typeof(SavingAccount))
                {
                    var acc = item as SavingAccount;
                    var termValue = acc.Term == -1 ? "Không thời hạn" : $"{acc.Term}";
                    Console.WriteLine($"{acc.AccountNumber,-20:d}{acc.Owner,-25:d}{acc.Bank,-15:d}" +
                        $"{acc.ReleaseDate,-15:d}{acc.Balance,-20:n}{acc.InterestRate / 100,-15:p}" +
                        $"{noData,-20:d}{termValue,-15:d}{acc.StartDate.ToString(format),-15:d}" +
                        $"{acc.EndDate.ToString(format),-15:d}{acc.CalculateInterest(),-20:n}");
                }
            }
        }

        // tạo danh sách tài khoản fake để test các chức năng
        private static void CreateFakeAccount(BankAccount[] bankAccounts, ref int numOfAccount)
        {
            var dateFormatter = "dd/MM/yyyy";
            bankAccounts[numOfAccount++] = new CheckingAccount("0021000435680", "TRAN VAN NAM",
                "Vietcombank", "05/22", 100000000, 1000000000);
            bankAccounts[numOfAccount++] = new CheckingAccount("0021000435681", "LE TAN TAI",
                "Vietcombank", "06/22", 120000000, 1000000000);
            bankAccounts[numOfAccount++] = new CheckingAccount("0021000435682", "NGUYEN BICH HOA",
                "Vietcombank", "07/22", 180000000, 500000000);
            bankAccounts[numOfAccount++] = new CheckingAccount("0021000435683", "HO HAI DANG",
                "Vietcombank", "08/22", 160000000, 500000000);
            bankAccounts[numOfAccount++] = new CheckingAccount("0021000435685", "MAI TUAN NGOC",
                "Vietcombank", "09/22", 15000000, 900000000);
            bankAccounts[numOfAccount++] = new SavingAccount("0021000435686", "LUU TRIEU VI",
                "Vietcombank", "10/22", 1950000000, 12, DateTime.ParseExact("15/10/2022", dateFormatter, null),
                DateTime.ParseExact("15/10/2023", dateFormatter, null));
            bankAccounts[numOfAccount++] = new SavingAccount("0021000435688", "LE VAN CONG",
                "Vietcombank", "09/22", 1500000000, 18, DateTime.ParseExact("10/06/2022", dateFormatter, null),
                DateTime.ParseExact("10/12/2023", dateFormatter, null));
        }
    }

    // interface mô tả các hành động của tài khoản ngân hàng
    interface IBanking
    {
        // hành động kiểm tra số dư
        void CheckBallance(string bankName);
        // hành động rút tiền
        long Withdraw(long amount, string bankName);
        // hành động nạp tiền
        long Deposit(long amount, string bankName);
        // hành động thanh toán
        long BankTransfer(BankAccount other, long amount, string bankName);
        // hành động thanh toán hóa đơn, dịch vụ
        long Pay(BankAccount target, long amount, string bankName);
        // hành động tính tiền lãi cuối kỳ
        long CalculateInterest();
    }

    // lớp cha trừu tượng mô tả thông tin, hành động của tài khoản ngân hàng
    class BankAccount
    {
        private static int autoId = 1000;
        public string AccountNumber { get; set; }
        public string Owner { get; set; }
        public string Bank { get; set; }
        public string ReleaseDate { get; set; }
        public long Balance { get; set; }
        public double InterestRate { get; set; }
        public long Interest { get; set; }

        public BankAccount() { }

        public BankAccount(string accNum)
        {
            if (accNum == null)
            {
                AccountNumber = $"002100043{autoId++}";
            }
            else
            {
                AccountNumber = accNum;
            }
        }

        public BankAccount(string accNum, string owner, string bank,
            string releaseDate, long balance, double interestRate) : this(accNum)
        {
            Owner = owner;
            Bank = bank;
            ReleaseDate = releaseDate;
            Balance = balance;
            InterestRate = interestRate;
        }

        // phương thức kiểm tra số dư
        public virtual void CheckBallance(string bankName)
        {
            Console.WriteLine("========== THÔNG TIN TÀI KHOẢN ==========");
            Console.WriteLine($"Số tài khoản: {AccountNumber}");
            Console.WriteLine($"Số dư: {Balance:n}đ");
            Console.WriteLine($"Ngày phát hành: {ReleaseDate}");
        }
        // phương thức rút tiền
        public virtual long Withdraw(long amount, string bankName)
        {
            if (amount <= Balance - 50000)
            {
                var fee = 1100;
                if (bankName.CompareTo(Bank) != 0)
                {
                    fee = 3300;
                }
                Balance = Balance - amount - fee;
                return (amount + fee);
            }
            return -1;
        }
        // phương thức nạp tiền
        public virtual long Deposit(long amount, string bankName)
        {
            if (amount < 0)
            {
                Console.WriteLine("==> Số tiền cần nạp không hợp lệ. <==");
                return -1;
            }
            else
            {
                Balance += amount;
                Console.WriteLine($"==> Tài khoản {AccountNumber}: +{amount:n}đ. <==");
                return amount;
            }
        }
        // thanh toán
        public virtual long BankTransfer(BankAccount other, long amount, string bankName)
        {
            if (other == null)
            {
                Console.WriteLine("==> Tài khoản đích không tồn tại. <==");
                return -1;
            }
            else
            {
                if (amount <= Balance - 50000)
                {
                    Balance -= amount;
                    other.Balance += amount;
                    var fee = 0;
                    if (bankName != null)
                    {
                        // chuyển tiền trên app
                        fee = 1100;
                        if (bankName.CompareTo(Bank) != 0) // chuyển tiền tại ATM
                        {
                            fee = 3300;
                        }
                    }
                    Balance -= fee;
                    Console.WriteLine($"==> Tài khoản {AccountNumber}: -{amount + fee:n}đ. <==");
                    Console.WriteLine($"==> Tài khoản {other.AccountNumber}: +{amount:n}đ. <==");
                    return amount;
                }
                else
                {
                    Console.WriteLine("==> Số dư không đủ. Chuyển tiền thất bại. <==");
                    return -1;
                }
            }
        }
        // thanh toán hóa đơn, dịch vụ
        public virtual long Pay(BankAccount target, long amount, string bankName)
        {
            if (target == null)
            {
                Console.WriteLine("==> Tài khoản đích không tồn tại. <==");
                return -1;
            }
            else
            {
                if (amount <= Balance - 50000)
                {
                    Balance -= amount;
                    target.Balance += amount;
                    var fee = 0;
                    if (bankName != null)
                    {
                        // thanh toán trên app
                        fee = 1100;
                        if (bankName.CompareTo(Bank) != 0) // thanh toán tại ATM
                        {
                            fee = 3300;
                        }
                    }
                    Balance -= fee;
                    Console.WriteLine($"==> Tài khoản {AccountNumber}: -{amount + fee:n}đ. <==");
                    return amount;
                }
                else
                {
                    Console.WriteLine("==> Số dư không đủ. Thanh toán thất bại. <==");
                    return -1;
                }
            }
        }
        // tính tiền lãi cuối kỳ
        public virtual long CalculateInterest()
        {
            Interest = (long)(InterestRate / 100 * Balance);
            return Interest;
        }
    }

    // lớp mô tả tài khoản thanh toán
    class CheckingAccount : BankAccount
    {
        public long PaymentLimit { get; set; }
        public long TotalPayment { get; set; } // tổng tiền thanh toán, rút, chuyển

        public CheckingAccount() { }

        public CheckingAccount(string bankAcc) : base(bankAcc) { }

        public CheckingAccount(string accNum, string owner, string bank,
            string releaseDate, long balance, long limit) :
            base(accNum, owner, bank, releaseDate, balance, 1)
        {
            PaymentLimit = limit;
            TotalPayment = 0;
        }

        private bool IsPaymentLimitOver(long amount)
        {
            if (amount + TotalPayment > PaymentLimit)
            {
                return true;
            }
            return false;
        }

        public override long BankTransfer(BankAccount other, long amount, string bankName)
        {
            if (amount <= Balance - 50000 && !IsPaymentLimitOver(amount))
            {
                return base.BankTransfer(other, amount, bankName);
            }
            else if (IsPaymentLimitOver(amount))
            {
                Console.WriteLine("==> Bạn đã vượt hạn mức thanh toán trong ngày. <==");
                Console.WriteLine("==> Số tiền có thể chuyển: " + (PaymentLimit - TotalPayment));
                return -1;
            }
            return -1;

        }

        public override void CheckBallance(string bankName)
        {
            base.CheckBallance(bankName);
            Console.WriteLine($"Loại tài khoản: Thanh toán");
            var dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
            Console.WriteLine($"Thời gian thực hiện: {DateTime.Now.ToString(dateTimeFormat)}");
            Console.WriteLine("=========================================");
        }

        public override long Deposit(long amount, string bankName)
        {
            if (base.Deposit(amount, bankName) > 0)
            {
                var fee = 0;
                if (bankName.CompareTo(Bank) != 0)
                {
                    fee = 35000;
                }
                Console.WriteLine($"==> Phí dịch vụ: {fee:n}đ");
                return amount;
            }
            return -1;
        }

        public override long Pay(BankAccount target, long amount, string bankName)
        {
            if (amount <= Balance - 50000 && !IsPaymentLimitOver(amount))
            {
                var paymentAmount = base.Pay(target, amount, bankName);
                return paymentAmount;
            }
            else if (IsPaymentLimitOver(amount))
            {
                Console.WriteLine("==> Bạn đã vượt hạn mức thanh toán trong ngày. <==");
                Console.WriteLine("==> Số tiền có thể chuyển: " + (PaymentLimit - TotalPayment));
                return -1;
            }
            return -1;
        }

        public override long Withdraw(long amount, string bankName)
        {
            if (amount <= Balance - 50000 && !IsPaymentLimitOver(amount))
            {
                TotalPayment += amount;
                var total = base.Withdraw(amount, bankName);
                var dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
                Console.WriteLine($"==> Tài khoản {AccountNumber}: -{total:n}đ. <==");
                Console.WriteLine($"==> Thời gian giao dịch: {DateTime.Now.ToString(dateTimeFormat)}");
                return total;
            }
            else if (IsPaymentLimitOver(amount))
            {
                Console.WriteLine("==> Bạn đã vượt hạn mức thanh toán trong ngày. <==");
                Console.WriteLine("==> Số tiền có thể chuyển: " + (PaymentLimit - TotalPayment));
                return -1;
            }
            else
            {
                Console.WriteLine("==> Số dư của bạn không đủ để thực hiện giao dịch này. <==");
                return -1;
            }
        }
    }

    // lớp mô tả tài khoản tiết kiệm
    class SavingAccount : BankAccount
    {
        public int Term { get; set; } // kì hạn
        public DateTime StartDate { get; set; } // ngày gửi
        public DateTime EndDate { get; set; } // ngày đáo hạn

        public SavingAccount() { }

        public SavingAccount(string accNum) : base(accNum) { }

        public SavingAccount(string accNum, string owner, string bank,
            string releaseDate, long balance, int term, DateTime start, DateTime end) :
            base(accNum, owner, bank, releaseDate, balance, 0)
        {
            Term = term;
            StartDate = start;
            EndDate = end;
            SetInterestRate();
        }

        public void SetInterestRate()
        {
            switch (Term)
            {
                case -1:
                    InterestRate = 3.0;
                    break;
                case 1:
                    InterestRate = 3.5;
                    break;
                case 3:
                    InterestRate = 4.5;
                    break;
                case 6:
                    InterestRate = 5;
                    break;
                case 12:
                    InterestRate = 5.5;
                    break;
                case 18:
                    InterestRate = 6;
                    break;
                case 24:
                    InterestRate = 6.5;
                    break;
                default:
                    InterestRate = 0;
                    break;
            }
        }

        public override long BankTransfer(BankAccount other, long amount, string bankName)
        {
            if (amount <= Balance - 50000)
            {
                var transferAmount = base.BankTransfer(other, amount, bankName);
                var fee = (int)(3.0 / 100 * amount);
                Balance -= fee;
                Console.WriteLine($"==> Tài khoản {AccountNumber}: -{transferAmount + fee:n}đ. <==");
                Console.WriteLine($"==> Tài khoản {other.AccountNumber}: +{amount:n}đ. <==");
                return transferAmount + fee;
            }
            return -1;
        }

        public override void CheckBallance(string bankName)
        {
            var format = "dd/MM/yyyy";
            var dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
            base.CheckBallance(bankName);
            Console.WriteLine($"Loại tài khoản: Tiết kiệm.");
            Console.WriteLine($"Ngày phát hành: {ReleaseDate}");
            Console.WriteLine($"Kỳ hạn: {Term} tháng.");
            Console.WriteLine($"Lãi suất: {InterestRate / 100:p}");
            Console.WriteLine($"Hiệu lực từ: {StartDate.ToString(format)}");
            Console.WriteLine($"Hiệu lực đến: {EndDate.ToString(format)}");
            Console.WriteLine($"Thời gian thực hiện: {DateTime.Now.ToString(dateTimeFormat)}");
            Console.WriteLine("=========================================");
        }

        public override long Deposit(long amount, string bankName)
        {
            if (base.Deposit(amount, bankName) > 0)
            {
                var fee = 0;
                if (bankName.CompareTo(Bank) != 0)
                {
                    fee = 35000;
                }
                Console.WriteLine($"==> Phí dịch vụ: {fee:n}đ");
                return amount;
            }
            return -1;
        }

        public override long Pay(BankAccount target, long amount, string bankName)
        {
            if (target == null)
            {
                Console.WriteLine("==> Tài khoản đích không tồn tại. <==");
                return -1;
            }
            else
            {
                if (amount <= Balance - 50000)
                {
                    Balance -= amount;
                    target.Balance += amount;
                    var fee = 0;
                    if (bankName != null)
                    {
                        // thanh toán trên app
                        fee = 1100;
                        if (bankName.CompareTo(Bank) != 0) // thanh toán tại ATM
                        {
                            fee = 3300;
                        }
                    }
                    fee += (int)(3.0 / 100 * amount);
                    Balance -= fee;
                    Console.WriteLine($"==> Tài khoản {AccountNumber}: -{amount + fee:n}đ. <==");
                    return amount;
                }
                else
                {
                    Console.WriteLine("==> Số dư không đủ. Thanh toán thất bại. <==");
                    return -1;
                }
            }
        }

        public override long Withdraw(long amount, string bankName)
        {
            if (amount <= Balance - 50000)
            {
                var wAmount = base.Withdraw(amount, bankName);
                var dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
                var fee = (int)(3.0 / 100 * amount);
                fee += (int)(3.0 / 100 * amount);
                Balance -= fee;
                Console.WriteLine($"==> Tài khoản {AccountNumber}: -{wAmount + fee:n}đ. <==");
                Console.WriteLine($"==> Thời gian giao dịch: {DateTime.Now.ToString(dateTimeFormat)}");
                return (amount + fee);
            }
            else
            {
                Console.WriteLine("==> Số dư của bạn không đủ để thực hiện giao dịch này. <==");
                return -1;
            }
        }
    }
}
