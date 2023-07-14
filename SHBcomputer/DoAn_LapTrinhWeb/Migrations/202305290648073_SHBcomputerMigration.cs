namespace DoAn_LapTrinhWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SHBcomputerMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                {
                    role_id = c.Int(nullable: false, identity: true),
                    role_name = c.String(nullable: false, maxLength: 50),
                    create_at = c.DateTime(nullable: false),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.role_id);

            CreateTable(
                "dbo.Permissions",
                c => new
                {
                    permission_id = c.Int(nullable: false, identity: true),
                    permission_name = c.String(nullable: false, maxLength: 50),
                    create_at = c.DateTime(nullable: false),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.permission_id);

            CreateTable(
                "dbo.RolesPermissions",
                c => new
                {
                    role_id = c.Int(nullable: false),
                    permission_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.role_id, t.permission_id })
                .ForeignKey("dbo.Permissions", t => t.permission_id, cascadeDelete: false)
                .ForeignKey("dbo.Roles", t => t.role_id, cascadeDelete: false);

            CreateTable(
                "dbo.Account",
                c => new
                {
                    account_id = c.Int(nullable: false, identity: true),
                    role_id = c.Int(),
                    password = c.String(maxLength: 100, unicode: false),
                    Email = c.String(maxLength: 100),
                    Requestcode = c.String(maxLength: 100),
                    Name = c.String(nullable: false, maxLength: 20),
                    Phone = c.String(nullable: false, maxLength: 10),
                    Avatar = c.String(maxLength: 500),
                    Dateofbirth = c.DateTime(nullable: false),
                    Gender = c.String(nullable: false, maxLength: 1),
                    create_by = c.String(maxLength: 100),
                    create_at = c.DateTime(nullable: false),
                    update_by = c.String(maxLength: 100),
                    update_at = c.DateTime(nullable: false),
                    expired_at = c.DateTime(nullable: false),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                })
                .PrimaryKey(t => t.account_id)
                .ForeignKey("dbo.Roles", t => t.role_id);

            CreateTable(
                "dbo.Provinces",
                c => new
                {
                    province_id = c.Int(nullable: false, identity: true),
                    province_name = c.String(nullable: false, maxLength: 50),
                    type = c.String(nullable: false, maxLength: 20),
                })
                .PrimaryKey(t => t.province_id);

            CreateTable(
                "dbo.Districts",
                c => new
                {
                    district_id = c.Int(nullable: false, identity: true),
                    province_id = c.Int(nullable: false),
                    district_name = c.String(nullable: false, maxLength: 50),
                    type = c.String(nullable: false, maxLength: 20),
                })
                .PrimaryKey(t => t.district_id)
                .ForeignKey("dbo.Provinces", t => t.province_id);

            CreateTable(
                "dbo.Wards",
                c => new
                {
                    ward_id = c.Int(nullable: false, identity: true),
                    district_id = c.Int(nullable: false),
                    ward_name = c.String(nullable: false, maxLength: 50),
                    type = c.String(nullable: false, maxLength: 20),
                })
                .PrimaryKey(t => t.ward_id)
                .ForeignKey("dbo.Districts", t => t.district_id);

            CreateTable(
                "dbo.Account_Address",
                c => new
                {
                    account_address_id = c.Int(nullable: false, identity: true),
                    account_id = c.Int(nullable: false),
                    account_address_phonenumber = c.String(maxLength: 10),
                    account_address_username = c.String(maxLength: 20),
                    province_id = c.Int(nullable: false),
                    district_id = c.Int(nullable: false),
                    ward_id = c.Int(nullable: false),
                    account_address_content = c.String(maxLength: 50),
                    account_address_default = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.account_address_id)
                .ForeignKey("dbo.Account", t => t.account_id, cascadeDelete: false)
                .ForeignKey("dbo.Districts", t => t.district_id, cascadeDelete: false)
                .ForeignKey("dbo.Provinces", t => t.province_id, cascadeDelete: false)
                .ForeignKey("dbo.Wards", t => t.ward_id, cascadeDelete: false);

            CreateTable(
                "dbo.Banner",
                c => new
                {
                    banner_id = c.Int(nullable: false, identity: true),
                    banner_name = c.String(nullable: false, maxLength: 200),
                    slug = c.String(maxLength: 209),
                    banner_start = c.DateTime(nullable: false),
                    banner_end = c.DateTime(nullable: false),
                    description = c.String(maxLength: 100),
                    image_thumbnail = c.String(nullable: false, maxLength: 500),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    create_at = c.DateTime(nullable: false),
                    banner_type = c.Int(nullable: false),
                    update_by = c.String(nullable: false, maxLength: 100),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.banner_id);

            CreateTable(
                "dbo.Brand",
                c => new
                {
                    brand_id = c.Int(nullable: false, identity: true),
                    brand_name = c.String(nullable: false, maxLength: 100),
                    brand_image = c.String(maxLength: 500),
                    slug = c.String(maxLength: 109),
                    description = c.String(maxLength: 200),
                    Web_directory = c.String(maxLength: 200),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    create_at = c.DateTime(nullable: false),
                    update_by = c.String(nullable: false, maxLength: 100),
                    update_at = c.DateTime(),
                })
                .PrimaryKey(t => t.brand_id);

            CreateTable(
                "dbo.Discount",
                c => new
                {
                    disscount_id = c.Int(nullable: false, identity: true),
                    discount_name = c.String(nullable: false, maxLength: 200),
                    discount_start = c.DateTime(nullable: false),
                    discount_end = c.DateTime(nullable: false),
                    discount_price = c.Double(nullable: false),
                    discount_max = c.Double(nullable: false),
                    discounts_code = c.String(maxLength: 20, unicode: false),
                    discounts_type = c.Int(nullable: false),
                    create_at = c.DateTime(nullable: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    discount_global = c.String(maxLength: 1),
                    quantity = c.String(maxLength: 10),
                    update_by = c.String(nullable: false, maxLength: 100),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.disscount_id);

            CreateTable(
                "dbo.ParentCategory",
                c => new
                {
                    parentcategory_id = c.Int(nullable: false, identity: true),
                    name = c.String(nullable: false, maxLength: 100),
                    slug = c.String(nullable: false, maxLength: 109),
                    image = c.String(nullable: false, maxLength: 500),
                    image2 = c.String(nullable: false, maxLength: 500),
                    category_description = c.String(maxLength: 100),
                    create_at = c.DateTime(nullable: false),
                    update_at = c.DateTime(nullable: false),
                    create_by = c.String(maxLength: 100),
                    update_by = c.String(maxLength: 100),
                    status = c.String(maxLength: 1),
                })
                .PrimaryKey(t => t.parentcategory_id);

            CreateTable(
                "dbo.ChildCategory",
                c => new
                {
                    childcategory_id = c.Int(nullable: false, identity: true),
                    parentcategory_id = c.Int(nullable: false),
                    name = c.String(nullable: false, maxLength: 100),
                    slug = c.String(nullable: false, maxLength: 150),
                    image = c.String(nullable: false, maxLength: 500),
                    image2 = c.String(nullable: false, maxLength: 500),
                    description = c.String(maxLength: 100),
                    create_at = c.DateTime(nullable: false),
                    update_at = c.DateTime(nullable: false),
                    create_by = c.String(maxLength: 100),
                    update_by = c.String(maxLength: 100),
                    status = c.String(maxLength: 1),
                })
                .PrimaryKey(t => t.childcategory_id)
                .ForeignKey("dbo.ParentCategory", t => t.parentcategory_id);

            CreateTable(
                "dbo.News",
                c => new
                {
                    news_id = c.Int(nullable: false, identity: true),
                    account_id = c.Int(nullable: false),
                    childcategory_id = c.Int(nullable: false),
                    news_title = c.String(nullable: false, maxLength: 500),
                    meta_title = c.String(nullable: false, maxLength: 150),
                    slug = c.String(nullable: false, maxLength: 159),
                    news_content = c.String(nullable: false),
                    ViewCount = c.Int(nullable: false),
                    image = c.String(nullable: false, maxLength: 500),
                    image2 = c.String(nullable: false, maxLength: 500),
                    create_at = c.DateTime(nullable: false),
                    update_at = c.DateTime(nullable: false),
                    update_by = c.String(maxLength: 100),
                    status = c.String(maxLength: 1),
                })
                .PrimaryKey(t => t.news_id)
                .ForeignKey("dbo.Account", t => t.account_id, cascadeDelete: false)
                .ForeignKey("dbo.ChildCategory", t => t.childcategory_id);

            CreateTable(
                "dbo.NewsComments",
                c => new
                {
                    comment_id = c.Int(nullable: false, identity: true),
                    account_id = c.Int(nullable: false),
                    news_id = c.Int(nullable: false),
                    comment_content = c.String(nullable: false, maxLength: 500),
                    create_at = c.DateTime(nullable: false),
                    status = c.String(maxLength: 1),
                })
                .PrimaryKey(t => t.comment_id)
                .ForeignKey("dbo.Account", t => t.account_id, cascadeDelete: false)
                .ForeignKey("dbo.News", t => t.news_id);

            CreateTable(
                "dbo.CommentLikes",
                c => new
                {
                    comment_like_id = c.Int(nullable: false, identity: true),
                    comment_id = c.Int(nullable: false),
                    account_id = c.Int(nullable: false),
                    comment_like = c.String(maxLength: 1),
                    create_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.comment_like_id)
                .ForeignKey("dbo.Account", t => t.account_id, cascadeDelete: false)
                .ForeignKey("dbo.NewsComments", t => t.comment_id, cascadeDelete: false);

            CreateTable(
                "dbo.ParentGenres",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(nullable: false, maxLength: 150),
                    slug = c.String(maxLength: 159),
                    icon = c.String(maxLength: 20),
                    image = c.String(maxLength: 500),
                    description = c.String(maxLength: 200),
                    status = c.String(maxLength: 1),
                    create_at = c.DateTime(nullable: false),
                    create_by = c.String(nullable: false, maxLength: 100),
                    update_by = c.String(nullable: false, maxLength: 100),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Genre",
                c => new
                {
                    genre_id = c.Int(nullable: false, identity: true),
                    parent_genre_id = c.Int(nullable: false),
                    genre_name = c.String(nullable: false, maxLength: 100),
                    slug = c.String(maxLength: 109),
                    genre_image = c.String(maxLength: 500),
                    description = c.String(maxLength: 200),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    create_at = c.DateTime(nullable: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    update_by = c.String(nullable: false, maxLength: 100),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.genre_id)
                .ForeignKey("dbo.ParentGenres", t => t.parent_genre_id);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                {
                    taxes_id = c.Int(nullable: false, identity: true),
                    taxes_name = c.String(nullable: false, maxLength: 50),
                    taxes_value = c.Int(nullable: false),
                    create_at = c.DateTime(nullable: false),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.taxes_id);

            CreateTable(
                "dbo.Product",
                c => new
                {
                    product_id = c.Int(nullable: false, identity: true),
                    genre_id = c.Int(nullable: false),
                    taxes_id = c.Int(),
                    brand_id = c.Int(nullable: false),
                    disscount_id = c.Int(nullable: false),
                    product_name = c.String(nullable: false, maxLength: 200),
                    title_seo = c.String(nullable: false, maxLength: 150),
                    slug = c.String(maxLength: 159),
                    price = c.Double(nullable: false),
                    view = c.Long(nullable: false),
                    buyturn = c.Long(nullable: false),
                    quantity = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    create_at = c.DateTime(nullable: false),
                    updateby = c.String(maxLength: 100),
                    update_at = c.DateTime(nullable: false),
                    image = c.String(maxLength: 500),
                    description = c.String(),
                    specification = c.String(),
                })
                .PrimaryKey(t => new { t.product_id, t.genre_id })
                .ForeignKey("dbo.Brand", t => t.brand_id)
                .ForeignKey("dbo.Discount", t => t.disscount_id)
                .ForeignKey("dbo.Genre", t => t.genre_id)
                .ForeignKey("dbo.Taxes", t => t.taxes_id);

            CreateTable(
                "dbo.Product_Image",
                c => new
                {
                    product_image_id = c.Int(nullable: false, identity: true),
                    product_id = c.Int(nullable: false),
                    genre_id = c.Int(nullable: false),
                    image_1 = c.String(maxLength: 500),
                    image_2 = c.String(maxLength: 500),
                    image_3 = c.String(maxLength: 500),
                    image_4 = c.String(maxLength: 500),
                    image_5 = c.String(maxLength: 500),
                    status = c.String(maxLength: 1),
                    create_by = c.String(maxLength: 100),
                    update_by = c.String(maxLength: 100),
                    create_at = c.DateTime(nullable: false),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.product_image_id)
                .ForeignKey("dbo.Product", t => new { t.product_id, t.genre_id }, cascadeDelete: false);

            CreateTable(
                "dbo.NewsProducts",
                c => new
                {
                    news_id = c.Int(nullable: false),
                    product_id = c.Int(nullable: false),
                    genre_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.news_id, t.product_id })
                .ForeignKey("dbo.Product", t => new { t.product_id, t.genre_id })
                .ForeignKey("dbo.News", t => t.news_id);

            CreateTable(
                "dbo.Banner_Detail",
                c => new
                {
                    banner_id = c.Int(nullable: false),
                    product_id = c.Int(nullable: false),
                    genre_id = c.Int(nullable: false),
                    id = c.Int(nullable: false, identity: true),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    create_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.banner_id, t.product_id, t.genre_id })
                .ForeignKey("dbo.Banner", t => t.banner_id)
                .ForeignKey("dbo.Product", t => new { t.product_id, t.genre_id }, cascadeDelete: false);

            CreateTable(
                "dbo.Feedback",
                c => new
                {
                    feedback_id = c.Int(nullable: false, identity: true),
                    account_id = c.Int(nullable: false),
                    product_id = c.Int(nullable: false),
                    genre_id = c.Int(nullable: false),
                    parent_feedback_id = c.Int(nullable: false),
                    description = c.String(maxLength: 200),
                    rate_star = c.Int(nullable: false),
                    create_at = c.DateTime(nullable: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    update_by = c.String(nullable: false, maxLength: 100),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.feedback_id, t.account_id })
                .ForeignKey("dbo.Product", t => new { t.product_id, t.genre_id }, cascadeDelete: false)
                .ForeignKey("dbo.Account", t => t.account_id);

            CreateTable(
                "dbo.Feedback_Image",
                c => new
                {
                    image_id = c.Int(nullable: false, identity: true),
                    feedback_id = c.Int(nullable: false),
                    account_id = c.Int(nullable: false),
                    image = c.String(unicode: false, storeType: "text"),
                    create_at = c.DateTime(nullable: false),
                    create_by = c.String(nullable: false, maxLength: 20, unicode: false),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    update_by = c.String(nullable: false, maxLength: 20),
                    update_at = c.DateTime(),
                })
                .PrimaryKey(t => t.image_id)
                .ForeignKey("dbo.Feedback", t => new { t.feedback_id, t.account_id }, cascadeDelete: false);

            CreateTable(
                "dbo.Payment",
                c => new
                {
                    payment_id = c.Int(nullable: false, identity: true),
                    payment_name = c.String(nullable: false, maxLength: 100),
                    create_at = c.DateTime(nullable: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    update_by = c.String(nullable: false, maxLength: 100),
                    Exchange_rates = c.String(maxLength: 30),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.payment_id);

            CreateTable(
                "dbo.Delivery",
                c => new
                {
                    delivery_id = c.Int(nullable: false, identity: true),
                    delivery_name = c.String(nullable: false, maxLength: 100),
                    price = c.Decimal(nullable: false, storeType: "money"),
                    create_at = c.DateTime(nullable: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    update_by = c.String(nullable: false, maxLength: 100),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.delivery_id);

            CreateTable(
                "dbo.OrderAddress",
                c => new
                {
                    order_address_id = c.Int(nullable: false, identity: true),
                    order_address_phonenumber = c.String(maxLength: 10),
                    order_address_username = c.String(maxLength: 20),
                    order_adress_email = c.String(maxLength: 100),
                    order_adress_province = c.String(maxLength: 50),
                    order_adress_district = c.String(maxLength: 50),
                    order_adress_wards = c.String(maxLength: 50),
                    order_address_content = c.String(maxLength: 150),
                    times_edit_adress = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.order_address_id);

            CreateTable(
                "dbo.Order",
                c => new
                {
                    order_id = c.Int(nullable: false, identity: true),
                    order_address_id = c.Int(nullable: false),
                    payment_id = c.Int(nullable: false),
                    delivery_id = c.Int(nullable: false),
                    oder_date = c.DateTime(nullable: false),
                    account_id = c.Int(nullable: false),
                    payment_transaction = c.String(maxLength: 1),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    order_note = c.String(maxLength: 200),
                    create_at = c.DateTime(nullable: false),
                    total = c.Double(nullable: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    update_by = c.String(nullable: false, maxLength: 100),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.Delivery", t => t.delivery_id)
                .ForeignKey("dbo.OrderAddress", t => t.order_address_id, cascadeDelete: false)
                .ForeignKey("dbo.Payment", t => t.payment_id)
                .ForeignKey("dbo.Account", t => t.account_id);

            CreateTable(
                "dbo.Order_Detail",
                c => new
                {
                    product_id = c.Int(nullable: false),
                    genre_id = c.Int(nullable: false),
                    order_id = c.Int(nullable: false),
                    price = c.Double(nullable: false),
                    status = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    discount_code = c.String(maxLength: 20),
                    quantity = c.Int(nullable: false),
                    create_by = c.String(nullable: false, maxLength: 100, unicode: false),
                    create_at = c.DateTime(nullable: false),
                    update_by = c.String(nullable: false, maxLength: 100),
                    update_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.product_id, t.genre_id, t.order_id })
                .ForeignKey("dbo.Order", t => t.order_id)
                .ForeignKey("dbo.Product", t => new { t.product_id, t.genre_id });

            CreateTable(
                "dbo.Tags",
                c => new
                {
                    tag_id = c.Int(nullable: false, identity: true),
                    tag_name = c.String(nullable: false, maxLength: 100),
                    slug = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.tag_id);

            CreateTable(
                "dbo.NewsTags",
                c => new
                {
                    news_id = c.Int(nullable: false),
                    tag_id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.news_id, t.tag_id })
                .ForeignKey("dbo.Tags", t => t.tag_id)
                .ForeignKey("dbo.News", t => t.news_id);

            CreateTable(
                "dbo.StickyPost",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    news_id = c.Int(nullable: false),
                    sticky_start = c.DateTime(nullable: false),
                    create_by = c.String(nullable: false, maxLength: 100),
                    update_by = c.String(nullable: false, maxLength: 100),
                    sticky_end = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.News", t => t.news_id);

            CreateTable(
                "dbo.Reply_Comments",
                c => new
                {
                    reply_comment_id = c.Int(nullable: false, identity: true),
                    comment_id = c.Int(nullable: false),
                    account_id = c.Int(nullable: false),
                    reply_comment_content = c.String(maxLength: 500),
                    create_at = c.DateTime(nullable: false),
                    status = c.String(maxLength: 1),
                })
                .PrimaryKey(t => t.reply_comment_id)
                .ForeignKey("dbo.Account", t => t.account_id, cascadeDelete: false)
                .ForeignKey("dbo.NewsComments", t => t.comment_id, cascadeDelete: false);

            CreateTable(
                "dbo.ReplyCommentLikes",
                c => new
                {
                    reply_like_id = c.Int(nullable: false, identity: true),
                    reply_comment_id = c.Int(nullable: false),
                    account_id = c.Int(nullable: false),
                    reply_like = c.String(maxLength: 1),
                    create_at = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.reply_like_id)
                .ForeignKey("dbo.Account", t => t.account_id, cascadeDelete: false)
                .ForeignKey("dbo.Reply_Comments", t => t.reply_comment_id, cascadeDelete: false);

            CreateTable(
                "dbo.API_Key",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        api_name = c.String(maxLength: 100),
                        api_decription = c.String(maxLength: 300),
                        client_id = c.String(maxLength: 500),
                        client_secret = c.String(maxLength: 500),
                        Return_Url = c.String(maxLength: 200),
                        active = c.Boolean(nullable: false),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        contact_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        phone = c.String(maxLength: 10),
                        email = c.String(nullable: false, maxLength: 100),
                        content = c.String(nullable: false, maxLength: 200),
                        image = c.String(maxLength: 500),
                        reply = c.String(),
                        flag = c.Int(nullable: false),
                        status = c.String(nullable: false, maxLength: 1),
                        create_by = c.String(nullable: false, maxLength: 100),
                        create_at = c.DateTime(nullable: false),
                        update_by = c.String(nullable: false, maxLength: 100),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.contact_id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Contact");
            DropTable("dbo.API_Key");
            DropTable("dbo.ReplyCommentLikes");
            DropTable("dbo.Reply_Comments");
            DropTable("dbo.StickyPost");
            DropTable("dbo.NewsTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Order_Detail");
            DropTable("dbo.Order");
            DropTable("dbo.OrderAddress");
            DropTable("dbo.Delivery");
            DropTable("dbo.Payment");
            DropTable("dbo.Feedback_Image");
            DropTable("dbo.Feedback");
            DropTable("dbo.Banner_Detail");
            DropTable("dbo.NewsProducts");
            DropTable("dbo.Product_Image");
            DropTable("dbo.Product");
            DropTable("dbo.Taxes");
            DropTable("dbo.Genre");
            DropTable("dbo.ParentGenres");
            DropTable("dbo.CommentLikes");
            DropTable("dbo.NewsComments");
            DropTable("dbo.News");
            DropTable("dbo.ChildCategory");
            DropTable("dbo.ParentCategory");
            DropTable("dbo.Discount");
            DropTable("dbo.Brand");
            DropTable("dbo.Banner");
            DropTable("dbo.Account_Address");
            DropTable("dbo.Wards");
            DropTable("dbo.Districts");
            DropTable("dbo.Provinces");
            DropTable("dbo.Account");
            DropTable("dbo.RolesPermissions");
            DropTable("dbo.Permissions");
            DropTable("dbo.Roles");
        }
    }
}
