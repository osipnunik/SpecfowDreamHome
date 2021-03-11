Feature: DreamHome
	Simple 

Scenario: As an administrator, I want to add new prizes for other users to view.
    Given user logged in as admin with "testqaanuitex@gmail.com" email and "1111111" password
    And click add new dream home
    When admin input title as "testHome11"
    When admin input address as "citing lang 2"
    When choose start and finish date
    When upload main picture
    #When swith in trending toggle
    When go to Description tab
    When input badroom desctiption as "<p>The primary bedroom is seriously spacious, with enough room for a king-sized bed, gorgeous built-in cupboards, more clothing storage-space, seating, and, wow, have you checked out the garden view from the massive private windows?</p>\n<p><br></p>\n<p>As big as the primary, in the second bedroom there’s enough space for another double bed, more seating, more clothes storage, and, just like the primary, it gets great light from its huge windows.</p>"
    When upload badroom picture
    When input bathroom desctiption as "The upstairs bathroom is such a beautiful and relaxing room. Whether you’re soaking in the tub on a lazy evening or getting ready for work in the morning, the floor-to-ceiling marble tiling will make you feel like royalty.Downstairs the half-bathroom has the most amazing wallpaper we’ve ever seen, and we are in love. It’s small enough to be inconspicuous but large enough to double as a mini utility room."
    When upload bathroom picture
    When input Outspace desctiption as "The private garden is a little piece of heaven hidden within the hustle and bustle of London. Spacious enough to host big parties or to just lounge around in during the hot summer months and feel a sense of calm surrounded by your very own Eden."
    When upload Outspace picture
    When input in about "Closing November 30, 2020!:house: Ticket threshold required in order to award the property: 650,000. Find out more about how this has been calculated https://help.rafflehouse.com/en/articles/4233916-why-the-ticket-threshold-to-award-the-property-is-set-at-650-000🎟️ What you get with a single ticket purchase::blue_circle: A donation to the homelessness charity that you select - do some good today while getting a ticket!:blue_circle: Entry into this week's £1,000 giveaway. Our £1,000 giveaways reset every Sunday night and there's a guaranteed winner!&nbsp;:blue_circle: And of course, your chance to win our Jackpot Prize, Stamp Duty &amp; legal fees paid!:moneybag: All that for £2! The more tickets you buy the more chances you’ll have to win £1,000 &amp; the property – oh, and the more you’ll donate to charity." text
    When upload floor plan picture
    When input in Take a Tour with Sara "https://www.youtube.com/embed/4Ae1wRND9-w" text
    When input in 3d Tour "https://my.matterport.com/show/?m=AVxfStTrNMH" text
    When input price as "3.40"
    When input Bed as "bed good"
    When input Bath as "Bath good"
    When input Garden as "Garden good"
    When input Transport as "Transport good"
    When input location as "Lenina 54"
    When input Freehold as "Freehold good"
    When input Tax as "67.99"
    When input Size as 68.6
    When input Energy as "nuclear reactor"
    When go to Discount & ticket tab
    When input ticket price value 6
    When input default number of tickets 15
    When click save button
    Then in new dream home table should be "testHome11" title
    When make "testHome11" active

