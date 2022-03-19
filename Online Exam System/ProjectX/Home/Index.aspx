<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProjectX.Home.Index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">

<head runat="server">
    <title>Online Examination System</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content=""/>
    <meta name="keywords" content=""/>
    <meta name="author" content="The Developers"/>

    <link href="/Content/CSS/bootstrap.min.css" rel="stylesheet"/>
    <link href="/Content/CSS/bootstrap-icons.css" rel="stylesheet"/>
    <link href="/Content/CSS/boxicons.min.css" rel="stylesheet"/>
    <link href="/Content/CSS/glightbox.min.css" rel="stylesheet"/>
    <link href="/Content/CSS/remixicon.css" rel="stylesheet"/>
    <link href="/Content/CSS/swiper-bundle.min.css" rel="stylesheet"/>
    <link href="/Content/CSS/index.css" rel="stylesheet"/>

    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Raleway:300,300i,400,400i,500,500i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet"/>
    <link href="https://unpkg.com/boxicons@2.0.9/css/boxicons.min.css" rel="stylesheet"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.1/font/bootstrap-icons.css" rel="stylesheet"/>
    <link href="https://cdn.jsdelivr.net/npm/remixicon@2.5.0/fonts/remixicon.css" rel="stylesheet"/>

    <style>
        :root {
            scroll-behavior: smooth;
        }

        .ct{
            margin-top: -25px;
        }

        .ct1, .ct2{
            position: relative;
            left: 5px;
        }

        .contactAddress{
            margin-top: -25px;
        }

        .ft{
            margin-left: 120px;
        }

        .features{
            margin-bottom: 40px;
        }

        .login{
            margin-left: -16px;
            margin-right: -5px;
        }
    </style>

</head>

<body>

    <header id="header" class="fixed-top d-flex align-items-center">
        <div class="container d-flex align-items-center justify-content-between">
            <div class="logo">
                <h1><a href="index.html">OES</a></h1>
            </div>
            <nav id="navbar" class="navbar">
                <ul>
                    <li><a class="nav-link scrollto active" href="#hero">Home</a></li>
                    <li><a class="nav-link scrollto" href="#about">About</a></li>
                    <li><a class="nav-link scrollto" href="#features">Features</a></li>
                    <li><a class="nav-link scrollto" href="#team">Team</a></li>
                    <li><a class="nav-link scrollto" href="#contact">Contact</a></li>
                    <li><a class="getstarted scrollto" href="/Registration/Login.aspx">Login</a></li>
                    <li class="login"><a class="getstarted scrollto" style="background-color: #d41313;" href="/Registration/TeacherLogin.aspx">Teacher</a></li>
                    <li class="login"><a class="getstarted scrollto" style="background-color: #1d667a;" href="/Registration/AdminLogin.aspx">Admin</a></li>
                </ul>
            </nav>
        </div>
    </header>

    <section id="hero" class="d-flex align-items-center">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 pt-5 pt-lg-0 order-2 order-lg-1 d-flex flex-column justify-content-center">
                    <h1 data-aos="fade-up">Online Exam System</h1>
                    <h2 data-aos="fade-up" data-aos-delay="400">OES acts as an online exam tool, a test-maker and an exam creator.</h2>
                    <div data-aos="fade-up" data-aos-delay="800">
                        <a href="/Registration/Signup.aspx" class="btn-get-started scrollto">Register Yourself</a>
                    </div>
                </div>
                <div class="col-lg-6 order-1 order-lg-2 hero-img" data-aos="fade-left" data-aos-delay="200">
                    <img src="/Content/Images/cover-img.png" class="img-fluid animated" alt=""/>
                </div>
            </div>
        </div>
    </section>

    <main id="main">

        <section id="clients" class="clients clients client-cover">
            <div class="container">
                <div class="row">
                    <div class="col-lg-2 col-md-4 col-6">
                        <img src="/Content/Images/client-1.png" class="img-fluid" alt="" data-aos="zoom-in"/>
                    </div>

                    <div class="col-lg-2 col-md-4 col-6">
                        <img src="/Content/Images/client-2.png" class="img-fluid" alt="" data-aos="zoom-in" data-aos-delay="100"/>
                    </div>

                    <div class="col-lg-2 col-md-4 col-6">
                        <img src="/Content/Images/client-3.png" class="img-fluid" alt="" data-aos="zoom-in" data-aos-delay="200"/>
                    </div>

                    <div class="col-lg-2 col-md-4 col-6">
                        <img src="/Content/Images/client-4.png" class="img-fluid" alt="" data-aos="zoom-in" data-aos-delay="300"/>
                    </div>

                    <div class="col-lg-2 col-md-4 col-6">
                        <img src="/Content/Images/client-5.png" class="img-fluid" alt="" data-aos="zoom-in" data-aos-delay="400"/>
                    </div>

                    <div class="col-lg-2 col-md-4 col-6">
                        <img src="/Content/Images/client-6.png" class="img-fluid" alt="" data-aos="zoom-in" data-aos-delay="500"/>
                    </div>
                </div>   
            </div>
        </section>


        <section id="about" class="about">
            <div class="container">
                <div class="section-title" data-aos="fade-up">
                    <h2>About Us</h2>
                </div>
                <div class="row content">
                    <div class="col-lg-6" data-aos="fade-up" data-aos-delay="150">
                        <p>OES offers scalability and flexibility to manage end to end process of question paper pattern to processing the results. OES provides many advantages, which are:</p>
                        <ul>
                            <li><i class="ri-check-double-line"></i> Envoirnment Friendly</li>
                            <li><i class="ri-check-double-line"></i> Saves You Money</li>
                            <li><i class="ri-check-double-line"></i> Saves Time, Big Time</li>
                        </ul>
                    </div>
                    <div class="col-lg-6 pt-4 pt-lg-0" data-aos="fade-up" data-aos-delay="300">
                        <p>OES is a technology-driven way to simplify examination activities like defining exam patterns with question banks, defining exam timer, objective/ subjective question sections, conducting exams using the computer or mobile devices in a paperless manner. It is a cost-effective, scalable way to convert traditional pen and paper-based exams to online and paperless mode.</p>
                        <a href="#" class="btn-learn-more">Learn More</a>
                    </div>
                </div>
            </div>
        </section>


        <section id="counts" class="counts ct">
            <div class="container">

                <div class="row">
                    <div class="image col-xl-5 d-flex align-items-stretch justify-content-center justify-content-xl-start" data-aos="fade-right" data-aos-delay="150">
                        <img src="/Content/Images/counts-img.svg" alt="" class="img-fluid" />
                    </div>

                    <div class="col-xl-7 d-flex align-items-stretch pt-4 pt-xl-0" data-aos="fade-left" data-aos-delay="300">
                        <div class="content d-flex flex-column justify-content-center">
                            <div class="row">
                                <div class="col-md-6 d-md-flex align-items-md-stretch ct1">
                                    <div class="count-box">
                                        <i class="bi bi-mortarboard"></i> 
                                        <span data-purecounter-start="0" data-purecounter-end="50" data-purecounter-duration="1" class="purecounter"></span>
                                        <p><strong>Total Students:</strong> Overall 50 Students are currently enrolled into OES</p>
                                    </div>
                                </div>

                                <div class="col-md-6 d-md-flex align-items-md-stretch">
                                    <div class="count-box">
                                        <i class="bi bi-journal-code"></i>
                                        <span data-purecounter-start="0" data-purecounter-end="5" data-purecounter-duration="1" class="purecounter"></span>
                                        <p><strong>Semester:</strong> Exams are available for 1-5 semesters only (Software Engineering)</p>
                                    </div>
                                </div>

                                <div class="col-md-6 d-md-flex align-items-md-stretch ct2">
                                    <div class="count-box">
                                       <i class="bi bi-card-checklist"></i>
                                        <span data-purecounter-start="0" data-purecounter-end="2" data-purecounter-duration="1" class="purecounter"></span>
                                        <p><strong>Exam:</strong> OES can conduct two types of exams i.e MCQs and True/False</p>
                                    </div>
                                </div>

                                <div class="col-md-6 d-md-flex align-items-md-stretch">
                                    <div class="count-box">
                                        <i class="bi bi-braces"></i>
                                        <span data-purecounter-start="0" data-purecounter-end="3" data-purecounter-duration="1" class="purecounter"></span>
                                        <p><strong>Modules:</strong> OES consists of 3 main modules i.e. Student, Faculty & Admin</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>


        <section id="features" class="features">
            <div class="container">

                <div class="section-title" data-aos="fade-up">
                    <h2>Features</h2>
                    <p>OES provide following features</p>
                </div>

                <div class="row" data-aos="fade-up" data-aos-delay="300">
                    <div class="col-lg-4 col-md-4">
                        <div class="icon-box">
                            <i class="ri-user-line ft" style="color: #ffbb2c;"></i>
                            <h3><a href="#">Student</a></h3>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 mt-4 mt-md-0">
                        <div class="icon-box">
                            <i class="ri-user-2-line ft" style="color: #5578ff;"></i>
                            <h3><a href="#">Teacher</a></h3>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 mt-4 mt-md-0">
                        <div class="icon-box">
                            <i class="ri-admin-line ft" style="color: #e80368; margin-left: 140px;"></i>
                            <h3><a href="#">Admin</a></h3>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-4 mt-4">
                        <div class="icon-box">
                            <i class="ri-edit-2-line" style="color: #4233ff;"></i>
                            <h3><a href="#">Give Exams</a></h3>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 mt-4">
                        <div class="icon-box">
                            <i class="ri-keyboard-line" style="color: #ffa76e;"></i>
                            <h3><a href="#">Create Exams</a></h3>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 mt-4">
                        <div class="icon-box">
                            <i class="ri-group-line" style="color: #29cc61;"></i>
                            <h3><a href="#">Manage Teachers</a></h3>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-4 mt-4">
                        <div class="icon-box">
                            <i class="ri-award-line" style="color: #b2904f;"></i>
                            <h3><a href="#">View Result</a></h3>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 mt-4">
                        <div class="icon-box">
                            <i class="ri-check-double-line" style="color: #b20969;"></i>
                            <h3><a href="#">Verify Result</a></h3>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 mt-4">
                        <div class="icon-box">
                            <i class="ri-calendar-2-line" style="color: #11dbcf;"></i>
                            <h3><a href="#">Manage Classes</a></h3>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-4 mt-4">
                        <div class="icon-box">
                            <i class="ri-profile-line" style="color: #e361ff;"></i>
                            <h3><a href="#">View Profile</a></h3>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 mt-4">
                        <div class="icon-box">
                            <i class="ri-team-line" style="color: #47aeff;"></i>
                            <h3><a href="#">Manage Students</a></h3>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 mt-4">
                        <div class="icon-box">
                            <i class="ri-broadcast-line" style="color: #ff5828;"></i>
                            <h3><a href="#">Give Notifications</a></h3>
                        </div>
                    </div>
                </div>

            </div>
        </section>


        <section id="team" class="team section-bg">
            <div class="container">

                <div class="section-title" data-aos="fade-up">
                    <h2>Team</h2>
                    <p>The Team that developed OES</p>
                </div>

                <div class="row">

                    <div class="col-lg-3 col-md-6 d-flex align-items-stretch">
                        <div class="member" data-aos="fade-up" data-aos-delay="100">
                            <div class="member-img">
                                <img src="/Content/Images/team.PNG" class="img-fluid" alt="Error loading image"/>
                                <div class="social">
                                    <a href="#"><i class="bi bi-twitter"></i></a>
                                    <a href="#"><i class="bi bi-facebook"></i></a>
                                    <a href="#"><i class="bi bi-instagram"></i></a>
                                    <a href="#"><i class="bi bi-linkedin"></i></a>
                                </div>
                            </div>
                            <div class="member-info">
                                <h4>Basit Khan</h4>
                                <span style="color: #938888">Chief Executive Officer</span>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-6 d-flex align-items-stretch">
                        <div class="member" data-aos="fade-up" data-aos-delay="200">
                            <div class="member-img">
                                <img src="/Content/Images/team.PNG" class="img-fluid" alt="Error loading image"/>
                                <div class="social">
                                    <a href="#"><i class="bi bi-twitter"></i></a>
                                    <a href="#"><i class="bi bi-facebook"></i></a>
                                    <a href="#"><i class="bi bi-instagram"></i></a>
                                    <a href="#"><i class="bi bi-linkedin"></i></a>
                                </div>
                            </div>
                            <div class="member-info">
                                <h4>Farooq Mirza</h4>
                                <span style="color: #938888">Product Manager</span>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-6 d-flex align-items-stretch">
                        <div class="member" data-aos="fade-up" data-aos-delay="300">
                            <div class="member-img">
                                <img src="/Content/Images/team.PNG" class="img-fluid" alt="Error loading image"/>
                                <div class="social">
                                    <a href="#"><i class="bi bi-twitter"></i></a>
                                    <a href="#"><i class="bi bi-facebook"></i></a>
                                    <a href="#"><i class="bi bi-instagram"></i></a>
                                    <a href="#"><i class="bi bi-linkedin"></i></a>
                                </div>
                            </div>
                            <div class="member-info">
                                <h4>SM Shoaib</h4>
                                <span style="color: #938888">Cheif Technology Officer</span>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-6 d-flex align-items-stretch">
                        <div class="member" data-aos="fade-up" data-aos-delay="400">
                            <div class="member-img">
                                <img src="/Content/Images/team.PNG" class="img-fluid" alt="Error loading image"/>
                                <div class="social">
                                    <a href="#"><i class="bi bi-twitter"></i></a>
                                    <a href="#"><i class="bi bi-facebook"></i></a>
                                    <a href="#"><i class="bi bi-instagram"></i></a>
                                    <a href="#"><i class="bi bi-linkedin"></i></a>
                                </div>
                            </div>
                            <div class="member-info">
                                <h4>Raja Humza</h4>
                                <span style="color: #938888">Project Manager</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>


        <section id="contact" class="contact">
            <div class="container">

                <div class="section-title" data-aos="fade-up">
                    <h2>Contact Us</h2>
                </div>

                <div class="row">

                    <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="100">
                        <div class="contact-about">
                            <h3>OES</h3>
                            <p>We are now available at different social platforms. You can now find us at</p>
                            <div class="social-links">
                                <a href="#" class="twitter"><i class="bi bi-twitter"></i></a>
                                <a href="#" class="facebook"><i class="bi bi-facebook"></i></a>
                                <a href="#" class="instagram"><i class="bi bi-instagram"></i></a>
                                <a href="#" class="linkedin"><i class="bi bi-linkedin"></i></a>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-6 mt-4 mt-md-0" data-aos="fade-up" data-aos-delay="200">
                        <div class="info">
                            <div>
                                <i class="ri-map-pin-line"></i>
                                <p>Clifton, Street 15</p>
                                <p class="contactAddress">Karachi, PK 75300</p>
                            </div>

                            <div>
                                <i class="ri-mail-send-line"></i>
                                <p>info.ProjectX@yahoo.com</p>
                            </div>

                            <div>
                                <i class="ri-phone-line"></i>
                                <p>+92 900 786 01</p>
                            </div>

                        </div>
                    </div>

                    <div class="col-lg-5 col-md-12" data-aos="fade-up" data-aos-delay="300">
                        <form action="forms/contact.php" method="post" role="form" class="php-email-form">
                            <div class="form-group">
                                <input type="text" name="name" class="form-control" id="name" placeholder="Your Name" required>
                            </div>
                            <div class="form-group">
                                <input type="email" class="form-control" name="email" id="email" placeholder="Your Email" required>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" name="subject" id="subject" placeholder="Subject" required>
                            </div>
                            <div class="form-group">
                                <textarea class="form-control" name="message" rows="5" placeholder="Message" required></textarea>
                            </div>
                            <div class="my-3">
                                <div class="loading">Loading</div>
                                <div class="error-message"></div>
                                <div class="sent-message">Your message has been sent. Thank you!</div>
                            </div>
                            <div class="text-center">
                                <button type="submit">Send Message</button></div>
                        </form>
                    </div>

                </div>

            </div>
        </section>

    </main>

    <footer id="footer">
        <div class="container">
            <div class="row d-flex align-items-center">
                <div class="col-lg-6 text-lg-left text-center">
                    <div class="copyright">
                        &copy; Copyright <strong>ProjectX</strong>. All Rights Reserved
                    </div>
                    <div class="credits">
                        Designed by <a href="#">The Developers</a>
                    </div>
                </div>
                <div class="col-lg-6">
                    <nav class="footer-links text-lg-right text-center pt-2 pt-lg-0">
                        <a href="#hero" class="scrollto">Home</a>
                        <a href="#about" class="scrollto">About</a>
                        <a href="#">Privacy Policy</a>
                        <a href="#">Terms of Use</a>
                    </nav>
                </div>
            </div>
        </div>
    </footer>

    <a href="#" class="back-to-top d-flex align-items-center justify-content-center"><i class="bi bi-arrow-up-short"></i></a>

    <script src="/Content/JS/purecounter.js"></script>
    <script src="/Content/JS/aos.js"></script>
    <script src="/Content/JS/bootstrap.bundle.min.js"></script>
    <script src="/Content/JS/glightbox.min.js"></script>
    <script src="/Content/JS/isotope.pkgd.min.js"></script>
    <script src="/Content/JS/swiper-bundle.min.js"></script>
    <script src="/Content/JS/validate.js"></script>
    <script src="/Content/JS/index.js"></script>

</body>

</html>