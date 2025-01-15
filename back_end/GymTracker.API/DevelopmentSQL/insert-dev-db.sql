CREATE OR REPLACE FUNCTION truncate_tables() RETURNS void AS $$
DECLARE
    statements CURSOR FOR
        SELECT tablename, schemaname FROM pg_tables
        WHERE tableowner = 'postgres' AND (schemaname = 'users' OR schemaname = 'trainings') AND tablename != '__EFMigrationsHistory';
BEGIN
    FOR stmt IN statements LOOP
            EXECUTE 'TRUNCATE TABLE ' || stmt.schemaname || '.' || quote_ident(stmt.tablename) || ' CASCADE;';
        END LOOP;
END;
$$ LANGUAGE plpgsql;
SELECT truncate_tables();

INSERT INTO users."Users" ("Id", "Email", "Password", "Salt", "IsActive", "UserRole")
VALUES
    (1, 'test1@example.com', '3QpMkG4D6/PRa6zcEnUK/orLO4s+YTs5XVh1GwUR/Wo=', 'rmHAx/BWnhm73UFcYSpdXg==', true, 1),
    (2, 'test2@example.com', '3QpMkG4D6/PRa6zcEnUK/orLO4s+YTs5XVh1GwUR/Wo=', 'rmHAx/BWnhm73UFcYSpdXg==', true, 1),
    (3, 'test3@example.com', '3QpMkG4D6/PRa6zcEnUK/orLO4s+YTs5XVh1GwUR/Wo=', 'rmHAx/BWnhm73UFcYSpdXg==', true, 1),
    (4, 'test4@example.com', '3QpMkG4D6/PRa6zcEnUK/orLO4s+YTs5XVh1GwUR/Wo=', 'rmHAx/BWnhm73UFcYSpdXg==', true, 1),
    (5, 'test5@example.com', '3QpMkG4D6/PRa6zcEnUK/orLO4s+YTs5XVh1GwUR/Wo=', 'rmHAx/BWnhm73UFcYSpdXg==', true, 1),
    (6, 'test6@example.com', '3QpMkG4D6/PRa6zcEnUK/orLO4s+YTs5XVh1GwUR/Wo=', 'rmHAx/BWnhm73UFcYSpdXg==', true, 1),
    (7, 'test7@example.com', '3QpMkG4D6/PRa6zcEnUK/orLO4s+YTs5XVh1GwUR/Wo=', 'rmHAx/BWnhm73UFcYSpdXg==', true, 1),
    (8, 'test8@example.com', '3QpMkG4D6/PRa6zcEnUK/orLO4s+YTs5XVh1GwUR/Wo=', 'rmHAx/BWnhm73UFcYSpdXg==', true, 1),
    (9, 'test9@example.com', '3QpMkG4D6/PRa6zcEnUK/orLO4s+YTs5XVh1GwUR/Wo=', 'rmHAx/BWnhm73UFcYSpdXg==', true, 1),
    (10, 'test10@example.com', '3QpMkG4D6/PRa6zcEnUK/orLO4s+YTs5XVh1GwUR/Wo=', 'rmHAx/BWnhm73UFcYSpdXg==', true, 1);

INSERT INTO users."GymMembers" ("Id", "UserId", "Name", "Surname", "Gender")
VALUES
    (1, 1, 'John', 'Doe', 0),
    (2, 2, 'Jane', 'Smith', 1),
    (3, 3, 'Mike', 'Johnson', 0),
    (4, 4, 'Emily', 'Williams', 1),
    (5, 5, 'David', 'Brown', 0),
    (6, 6, 'Laura', 'Davis', 1),
    (7, 7, 'James', 'Miller', 0),
    (8, 8, 'Sophia', 'Wilson', 1),
    (9, 9, 'Daniel', 'Moore', 0),
    (10, 10, 'Olivia', 'Taylor', 1);

INSERT INTO trainings."TrainingTypes" ("Id", "Name")
VALUES
    (1, 'Cardio'),
    (2, 'Powerlifting'),
    (3, 'Yoga'),
    (4, 'HIIT'),
    (5, 'CrossFit');

INSERT INTO trainings."Trainings" ("Id", "Duration", "CaloriesBurned", "TrainingDifficulty", "Tiredness", "Notes", "TrainingDate", "TrainingTypeId", "GymMemberId")
VALUES
    (76, 45, 350, 6, 5, 'Good endurance session.', '2024-11-01', 1, 1),
    (77, 60, 450, 8, 7, 'Challenging, but felt great.', '2024-11-02', 2, 2),
    (78, 35, 280, 5, 4, 'Focus on form today.', '2024-11-03', 3, 3),
    (79, 50, 380, 7, 6, 'Felt stronger today.', '2024-11-04', 4, 4),
    (80, 55, 430, 8, 7, 'Pushed myself harder today.', '2024-11-05', 5, 5),
    (81, 45, 340, 7, 6, 'Felt tired but good progress.', '2024-11-06', 1, 6),
    (82, 60, 470, 9, 8, 'Intense but worth it!', '2024-11-07', 2, 7),
    (83, 30, 240, 6, 5, 'Great warm-up session.', '2024-11-08', 3, 8),
    (84, 40, 320, 7, 6, 'Felt like I could push more.', '2024-11-09', 4, 9),
    (85, 50, 400, 8, 7, 'Challenging but rewarding.', '2024-11-10', 5, 10),
    (86, 45, 350, 7, 6, 'Good balance of intensity and recovery.', '2024-11-11', 1, 1),
    (87, 50, 390, 8, 7, 'Tired but accomplished.', '2024-11-12', 2, 2),
    (88, 40, 310, 6, 5, 'Maintained good form throughout.', '2024-11-13', 3, 3),
    (89, 45, 340, 7, 6, 'Focus on consistency.', '2024-11-14', 4, 4),
    (90, 55, 430, 9, 8, 'High-intensity session!', '2024-11-15', 5, 5),
    (91, 60, 460, 9, 8, 'Pushed to my limit.', '2024-11-16', 1, 6),
    (92, 30, 230, 5, 4, 'Light but effective session.', '2024-11-17', 2, 7),
    (93, 40, 320, 6, 5, 'Good mix of cardio and strength.', '2024-11-18', 3, 8),
    (94, 50, 380, 7, 6, 'Good strength-focused training.', '2024-11-19', 4, 9),
    (95, 55, 440, 8, 7, 'Great pace, felt in control.', '2024-11-20', 5, 10),
    (96, 45, 350, 7, 6, 'Felt good during the entire session.', '2024-11-21', 1, 1),
    (97, 60, 470, 9, 8, 'Very tiring, but rewarding.', '2024-11-22', 2, 2),
    (98, 35, 280, 6, 5, 'Smooth pace, good session.', '2024-11-23', 3, 3),
    (99, 50, 400, 8, 7, 'Challenging but felt accomplished.', '2024-11-24', 4, 4),
    (100, 55, 430, 8, 7, 'Nice and intense workout!', '2024-11-25', 5, 5),
    (101, 45, 340, 7, 6, 'Felt strong throughout the session.', '2024-11-26', 1, 6),
    (102, 60, 460, 9, 8, 'Great challenge today!', '2024-11-27', 2, 7),
    (103, 30, 240, 6, 5, 'Focus on breathing and pacing.', '2024-11-28', 3, 8),
    (104, 40, 310, 7, 6, 'Improved my form today.', '2024-11-29', 4, 9),
    (105, 50, 380, 8, 7, 'Definitely felt the burn!', '2024-11-30', 5, 10),
    (106, 45, 350, 7, 6, 'Solid workout, good energy.', '2024-12-01', 1, 1),
    (107, 50, 390, 8, 7, 'Good consistency throughout the session.', '2024-12-02', 2, 2),
    (108, 40, 320, 6, 5, 'Focus on flexibility.', '2024-12-03', 3, 3),
    (109, 45, 340, 7, 6, 'Great pace, but needed more rest.', '2024-12-04', 4, 4),
    (110, 55, 430, 9, 8, 'Tough, but pushed through it!', '2024-12-05', 5, 5),
    (111, 60, 470, 9, 8, 'Definitely felt the effort today.', '2024-12-06', 1, 6),
    (112, 30, 230, 6, 5, 'Light session, but effective.', '2024-12-07', 2, 7),
    (113, 40, 320, 6, 5, 'Focus on technique today.', '2024-12-08', 3, 8),
    (114, 50, 380, 7, 6, 'Great intensity, great results.', '2024-12-09', 4, 9),
    (115, 55, 440, 8, 7, 'Good pace, but felt tired at the end.', '2024-12-10', 5, 10),
    (116, 45, 350, 7, 6, 'Felt strong, great progress.', '2024-12-11', 1, 1),
    (117, 60, 470, 9, 8, 'Challenging, but felt amazing afterward.', '2024-12-12', 2, 2),
    (118, 35, 270, 5, 4, 'Focused on endurance.', '2024-12-13', 3, 3),
    (119, 50, 400, 8, 7, 'Really intense, but rewarding.', '2024-12-14', 4, 4),
    (120, 55, 430, 8, 7, 'Felt like I could do more.', '2024-12-15', 5, 5),
    (121, 45, 340, 7, 6, 'Good pace, good recovery.', '2024-12-16', 1, 6),
    (122, 60, 460, 9, 8, 'Tough session, but worth it.', '2024-12-17', 2, 7),
    (123, 30, 230, 6, 5, 'Felt focused today.', '2024-12-18', 3, 8),
    (124, 40, 310, 7, 6, 'Worked on my flexibility.', '2024-12-19', 4, 9),
    (125, 50, 380, 8, 7, 'Intense and fulfilling session.', '2024-12-20', 5, 10),
    (126, 45, 350, 7, 6, 'Pushed through the difficult parts.', '2024-12-21', 1, 1),
    (127, 50, 390, 8, 7, 'Good session, with steady intensity.', '2024-12-22', 2, 2),
    (128, 40, 320, 6, 5, 'Worked on form and posture.', '2024-12-23', 3, 3),
    (129, 45, 340, 7, 6, 'Great energy today!', '2024-12-24', 4, 4),
    (130, 55, 430, 8, 7, 'Pushed myself harder this time.', '2024-12-25', 5, 5),
    (131, 60, 470, 9, 8, 'Great challenge today.', '2024-12-26', 1, 6),
    (132, 30, 230, 6, 5, 'Light and steady session.', '2024-12-27', 2, 7),
    (133, 40, 320, 6, 5, 'Good form focus.', '2024-12-28', 3, 8),
    (134, 50, 380, 7, 6, 'Focused on speed and endurance.', '2024-12-29', 4, 9),
    (135, 55, 440, 8, 7, 'Pushed myself harder.', '2024-12-30', 5, 10),
    (136, 45, 350, 7, 6, 'Felt stronger as I went on.', '2024-12-31', 1, 1),
    (137, 60, 470, 9, 8, 'Exhausting but rewarding.', '2024-12-31', 2, 2),
    (138, 35, 270, 6, 5, 'Great session, felt controlled.', '2024-12-31', 3, 3),
    (139, 50, 400, 8, 7, 'Challenge accepted!', '2024-12-31', 4, 4),
    (140, 55, 430, 8, 7, 'Pushed harder, felt amazing.', '2024-12-31', 5, 5);