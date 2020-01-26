Public Class Form1
    Dim ball(10000) As PictureBox 'ball data storage
    Dim Lpad(10000) As PictureBox 'left pad data storage
    Dim rpad(10000) As PictureBox 'right pad data storage
    Dim tpad(10000) As PictureBox 'top pad data storage
    Dim bpad(10000) As PictureBox 'bottom pad data storage
    Dim powerupitem(10000) As PictureBox
    Dim score As Integer 'stores the score
    Dim gamelost As Boolean = False 'tracks whether the game has been lost or not
    Dim mouselocation As Point 'stores mouse data
    Dim mousexpos, mouseypos As Integer 'stores the x and y coordinates of the mouse
    Dim ballxpos, ballypos As Integer 'stores the x and y coordinates of the ball
    Dim topc, bottomc, leftc, rightc, ballc, powerupc As Integer 'counter for the place in data storage being used
    Dim paddlewidth As Integer = 30 'easy to change storage of paddlewidth
    Dim paddleheight As Integer = 10 'easy changeable paddle height size
    Dim ballsize As Integer = 10 'easily changeable ball size
    Dim speed As Integer = 2 'easily changeable speed modifier (going to be used in next edition of program)
    Dim xVel, yvel As Single 'stores the xspeed and yspeed of the ball
    Dim yrand, xrand As Integer 'stores random x and y values which are used to generate which direction the ball moves in
    Dim firstclock As Boolean = True 'for checking if this is the first run through of the game code to avoid errors
    Dim toppos, leftpos As Integer 'for storing the position for drawing the powerup
    Dim powerupfirst As Boolean = True 'for checking if this is the first powerup creation called
    Dim clockspeed As Integer = 15 'set the game tick speed
    Dim powerups(10, 1) As String 'for storing activated powerup and their respective time left
    Dim numofpowerups As Integer = 2 'the number of powerups i have created +1 (array starts at 0)
    Dim bounce As Boolean = False 'to stop the ball from rebounding twice and passing through the paddle (occurs at high velocities)

    Private Sub HowToPlayBT_Click(sender As Object, e As EventArgs) Handles HowToPlayBT.Click 'when the how to play button is pressed 
        Form2.Show() 'show the how to play form
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DifficultyOptions.SelectedIndexChanged 'when the difficulty box setting has changed then
        speed = DifficultyOptions.Text + 1 'change the speed multiplier to whatever the difficulty is +1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles PlayBT.Click 'when the play button is clicked
        Me.Timer_clock.Enabled = True 'enable the game clock
        Randomize() 'open the built in randomizer
        xrand = CInt(Int((9 * Rnd()) + 1)) 'get a random number between 1 and 9
        yrand = CInt(Int((9 * Rnd()) + 1)) 'get a random number between 1 and 9
        xVel = Math.Cos(xrand) * speed 'do maths to get the xvelocity
        yvel = Math.Sin(yrand) * speed 'do maths to get the yvelocity

        While xVel < 1.5 And yvel < 1.5 And (Math.Cos(xrand) > 0.25 Or Math.Cos(xrand) < 0.25) And (Math.Sin(yrand) > 0.25 Or Math.Sin(yrand) < 0.25) 'check to avoid the ball bouncing vertically or horizontally
            xrand = CInt(Int((9 * Rnd()) + 1)) 'get a random number between 1 and 9
            yrand = CInt(Int((9 * Rnd()) + 1)) 'get a random number between 1 and 9
            xVel = Math.Cos(xrand) * speed 'do maths to get the xvelocity
            yvel = Math.Sin(yrand) * speed 'do maths to get the yvelocity
        End While
        ballxpos = (Gamewindow.Size.Width / 2) - ballsize / 2 'set the xposition at gamestart to the center of the window
        ballypos = (Gamewindow.Size.Height / 2) - ballsize / 2 'set the yposition at game start to the center of the window
        SpongIMG.Hide() 'hide a variety of items on the opening screen so they dont get in the way
        DifficultyOptions.Hide()
        HowToPlayBT.Hide()
        DifficultyLB.Hide()
        PlayBT.Hide()
        'disable for testing
        Cursor.Hide() 'hide the cursor to make the game harder and to avoid it getting in the way
        poweron.Hide() 'hide another item from the opening screen
        paddlewidth = 30 'set the original settings for the variables
        paddleheight = 10
        ballsize = 10
        For i = 0 To 10 'reset the powerup array 
            powerups(i, 0) = 0
            powerups(i, 1) = 0
        Next
        ReDim powerups(10, 1)
        score = 0 'reset the score value
        gamelost = False 'tell the game it is not lost
        If poweron.Checked = True Then 'if powerups are ectivated then
            powerup() 'go to the powerup subroutine
        End If
    End Sub

    Sub drawwithmouse()
        Gamewindow.Height = Me.Height - 38 'make the game screen scale with the size of the window
        Gamewindow.Width = Me.Width - 14 'make the game screen scale with the size of the window

        If firstclock = False Then 'if this isnt the first time running the program then
            tpad(topc).Dispose() 'delete the current paddle data
        End If
        tpad(topc) = New PictureBox
        With tpad(topc)
            .Height = paddleheight
            .Width = paddlewidth
            .BackColor = Color.White
            .Top = 10
            .Left = (mousexpos - (paddlewidth / 2))
        End With
        Me.Controls.Add(tpad(topc)) 'create a new top paddle with the above parameters
        tpad(topc).BringToFront() 'bring the created paddle infront of the background to show the user

        If firstclock = False Then 'if this isnt the first time running the program then
            bpad(bottomc).Dispose() 'delete the current paddle data
        End If
        bpad(bottomc) = New PictureBox
        With bpad(bottomc)
            .Height = paddleheight
            .Width = paddlewidth
            .BackColor = Color.White
            .Top = Gamewindow.Size.Height - (10 + paddleheight)
            .Left = (mousexpos - (paddlewidth / 2))
        End With
        Me.Controls.Add(bpad(bottomc)) 'create a new bottom paddle with the above parameters
        bpad(bottomc).BringToFront() 'bring the created paddle infront of the background to show the user

        If firstclock = False Then 'if this isnt the first time running the program then
            Lpad(leftc).Dispose() 'delete the current paddle data
        End If
        Lpad(leftc) = New PictureBox
        With Lpad(leftc)
            .Height = paddlewidth
            .Width = paddleheight
            .BackColor = Color.White
            .Top = mouseypos - (paddlewidth / 2)
            .Left = 10
        End With
        Me.Controls.Add(Lpad(leftc)) 'create a new left paddle with the above parameters
        Lpad(leftc).BringToFront() 'bring the created paddle infront of the background to show the user

        If firstclock = False Then 'if this isnt the first time running the program then
            rpad(rightc).Dispose() 'delete the current paddle data
        End If
        rpad(rightc) = New PictureBox
        With rpad(rightc)
            .Height = paddlewidth
            .Width = paddleheight
            .BackColor = Color.White
            .Top = mouseypos - (paddlewidth / 2)
            .Left = Gamewindow.Size.Width - (10 + paddleheight)
        End With
        Me.Controls.Add(rpad(rightc)) 'create a new right paddle with the above parameters
        rpad(rightc).BringToFront() 'bring the created paddle infront of the background to show the user
    End Sub

    Private Sub clocktick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_clock.Tick
        If gamelost = False Then ' if the game has not ended then
            Gamewindow.CreateGraphics.Clear(Color.DarkSlateBlue) 'reset the background
            drawwithmouse() 'run the drawwithmouse subroutine
            balllogic() 'run the balllogic subroutine
            bounce = False 'set bounce to false allowing the ball to bounce once again
            firstclock = False 'tell the game it is no longer the first run through of code
            Timer_clock.Interval = clockspeed
            Me.Text = "Score: " & score 'show score in the name of the window
            If poweron.Checked = True Then 'if powerups are on then
                powerupchecks() 'go to the powerup check subroutine
                If CInt(Int(((5000) * Rnd()) + 0)) > 4990 Then 'essentially a 1 in 500 roll to 
                    powerup() 'go to the powerup subroutine
                End If
            End If
        End If
    End Sub

    Private Sub mousemove(sender As Object, mouseinfo As MouseEventArgs) Handles Gamewindow.MouseMove 'when the mouse is moved
        mousexpos = mouseinfo.X 'update the xcoordinate
        mouseypos = mouseinfo.Y 'update the ycoordinate
    End Sub

    Sub balllogic() 'when the ball logic subroutine is called
        If firstclock = False Then 'if this is not the first cycle
            ball(ballc).Dispose() 'delete any previous data on the gamewindow
        End If
        ball(ballc) = New PictureBox 'create a new object called ball
        With ball(ballc)
            .Height = ballsize
            .Width = ballsize
            .BackColor = Color.Tomato
            .Top = ballypos - (ballsize / 2)
            .Left = ballxpos - (ballsize / 2)
        End With
        Me.Controls.Add(ball(ballc)) 'create a ball on the gamewindow using the above parameters
        ball(ballc).BringToFront() 'bring the ball infront of the background so the user can view it
        If ball(ballc).Bounds.IntersectsWith(rpad(rightc).Bounds) Or ball(ballc).Bounds.IntersectsWith(Lpad(leftc).Bounds) Then 'if the ball touches the side paddles then
            My.Computer.Audio.Play("E:\Project\Latest\Paddlehit.WAV")
            score += 1 'add one to score
            xVel = -xVel 'flip the xvelocity so it rebounds
            If xVel < 0 Then 'increase the speed of the ball
                xVel -= 0.1
            Else
                xVel += 0.1
            End If
            bounce = True 'set bounce to true so that it cant bounce twice in the same game tick
        End If

        If ball(ballc).Bounds.IntersectsWith(tpad(topc).Bounds) Or ball(ballc).Bounds.IntersectsWith(bpad(bottomc).Bounds) Then 'if the ball touches the top or bottom paddles then
            My.Computer.Audio.Play("E:\Project\Latest\Paddlehit.WAV")
            score += 1 'add one to score
            yvel = -yvel 'flip the velocity so it rebounds
            If yvel < 0 Then 'increase the speed of the ball
                yvel -= 0.1
            Else
                yvel += 0.1
            End If
            bounce = True
        End If
        If poweron.Checked = True Then
            If ball(ballc).Bounds.IntersectsWith(powerupitem(powerupc).Bounds) Then 'if the ball touches a powerup then
                powerupitem(powerupc).SetBounds(0, 0, 0, 0) 'hide the powerup from the gamewindow
                Gamewindow.CreateGraphics.Clear(Color.DarkSlateBlue) 'clear the whole gamewindow
                For i = 0 To (powerups.Length / 2) - 1 'go through each item already in the powerup array (incase a powerup is already active)
                    If powerups(i, 0) = Nothing Or powerups(i, 0) = "" Then 'if there is an empty space then 
                        Randomize()
                        My.Computer.Audio.Play("E:\Project\Latest\Powerup.WAV")
                        Dim poweruptype As Integer = CInt(Int(((numofpowerups + 1) * Rnd()) + 0))  'get a random powerup number 
                        powerups(i, 0) = poweruptype 'store the number of the powerup in the array
                        powerups(i, 1) = 500 'set the timer countdown to 500 (500 game ticks of powerup length)
                        If poweruptype = 0 Then 'if the powerup number was 0, increase paddle size
                            paddlewidth += 20
                        ElseIf poweruptype = 1 Then 'if the powerup number was 1 then make the ball larger
                            ballsize += 10
                        ElseIf poweruptype = 2 Then 'if the powerup number was 2 then increase speed of the ball
                            speed += 2
                        End If
                        Exit Sub
                    End If
                Next
            End If
        End If
        If bounce = True Then 'if the ball has bounced then
            ballypos += yvel * 3 'move the ball 3 times the distance it normally would
            ballxpos += xVel * 3
        Else
            ballypos += yvel 'otherwise move it normally
            ballxpos += xVel
        End If
        If ballxpos < 0 Or ballypos < 0 Or ballxpos > Me.Width Or ballypos > Me.Height Then 'if the ball has exited the game screen then
            gamelost = True 'tell the game it has been lost
            Cursor.Show() 'show the cursor
            MsgBox("Your score was: " & score, , "Game over!") 'tell the user their score and that they have lost
            If poweron.Checked = True Then 'if powerups are on then clear the powerups
                powerupitem(powerupc).Dispose()
            End If
            rpad(rightc).Dispose() 'reset all items on the gamewindow
            Lpad(leftc).Dispose()
            tpad(topc).Dispose()
            bpad(bottomc).Dispose()
            ball(ballc).Dispose()
            Gamewindow.CreateGraphics.Clear(Color.Gray)
            PlayBT.Show() 'show all of the items from the home screen that were previously hidden
            HowToPlayBT.Show()
            SpongIMG.Show()
            poweron.Show()
            DifficultyOptions.Show()
            DifficultyLB.Show()
        End If
    End Sub

    Sub powerup()
        If powerupfirst = False Then 'if this is not the first run through this section of code
            powerupitem(powerupc).Dispose() 'delete previous stored powerupitem data
        End If
        toppos = CInt(Int(((Gamewindow.Size.Height - 70) * Rnd()) + 70)) ' get a random location within the center of the gamewindow
        leftpos = CInt(Int(((Gamewindow.Size.Width - 70) * Rnd()) + 70)) ' get a random location within the center of the gamewindow
        powerupitem(powerupc) = New PictureBox 'initiate a location to store picturebox data
        With powerupitem(powerupc)
            .Height = 20
            .Width = 20
            .BackColor = Color.Pink
            .Top = toppos
            .Left = leftpos
        End With
        Me.Controls.Add(powerupitem(powerupc)) 'when this is called, create a powerup on the gamewindow
        powerupitem(powerupc).BringToFront() 'bring it to the front so it is able to be seen
        powerupfirst = False 'tell the game any subsequent run through is not the first 
    End Sub

    Sub powerupchecks()
        For i = 0 To (powerups.Length / 2) - 1 'loop through each powerup that is active in the array
            If powerups(i, 0) <> Nothing Or powerups(i, 0) <> "" Then 'if the location in the array is not empty then
                powerups(i, 1) -= 1 'minus one from the timer
                If powerups(i, 1) = 0 Then 'if the timer is now 0 then
                    My.Computer.Audio.Play("E:\Project\Latest\Powerdown.WAV")
                    If powerups(i, 0) = 0 Then  'if the powerup was a 0 then
                        paddlewidth -= 20 'shrink the paddles back to original size
                    ElseIf powerups(i, 0) = 1 Then 'if the powerup was a 1 then
                        ballsize -= 10 'shrink the ball back to original size
                    ElseIf powerups(i, 0) = 2 Then 'if the powerup was a 2 then
                        speed -= 2 'slow the ball back down to original speed
                    End If
                    powerups(i, 0) = Nothing 'empty the array location after removing the powerup
                End If
            End If
        Next
    End Sub
End Class