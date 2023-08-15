#define firstTEST1

using Microsoft.EntityFrameworkCore;
using ModelBuilderStudy.Model2;

#if firstTEST
using (Classes db = new())
{
    //기존 DB가 존재할 경우 삭제
    bool deleted = await db.Database.EnsureDeletedAsync();

    //Model로 부터 DB를 만들고 필요한 SQL Script를 생성
    bool created = await db.Database.EnsureCreatedAsync();

    Score _score = new Score() { ScoreId = 5, ScoreName = "Z1" };
    db.Add(_score);
    await db.SaveChangesAsync();
    Score _scoreUpdate = new Score() { ScoreId = 1, ScoreName = "1Z1" };
    db.Update(_scoreUpdate);
    await db.SaveChangesAsync();
    Console.WriteLine("ok");
    ////생성된 Script확인
    ////Console.WriteLine(a.Database.GenerateCreateScript());

    ////DB생성 후 기본데이터 확인
    //foreach (Student s in db.Students.Include(c => c.Courses))
    //{
    //    Console.WriteLine($"{s.StudentName}학생의 신청과목 총{s.Courses.Count}개");
    //    foreach (Course c in s.Courses)
    //    {
    //        Console.WriteLine($" {c.CourseName}");
    //    }
    //}
}

Classes _db = new();
Score _score1 = new Score() { ScoreId = 15, ScoreName = "Z1231" };
_db.Add(_score1);
await _db.SaveChangesAsync();
#else
DBConextStudy _dBConextStudy = new DBConextStudy();
#endif