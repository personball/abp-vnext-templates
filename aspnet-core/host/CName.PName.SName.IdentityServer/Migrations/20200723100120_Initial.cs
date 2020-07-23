using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CName.PName.SName.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    ApplicationName = table.Column<string>(maxLength: 96, nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    tenant_name = table.Column<string>(nullable: true),
                    ImpersonatorUserId = table.Column<Guid>(nullable: true),
                    ImpersonatorTenantId = table.Column<Guid>(nullable: true),
                    execution_time = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    ClientId = table.Column<string>(maxLength: 64, nullable: true),
                    CorrelationId = table.Column<string>(maxLength: 64, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    HttpMethod = table.Column<string>(maxLength: 16, nullable: true),
                    Url = table.Column<string>(maxLength: 256, nullable: true),
                    Exceptions = table.Column<string>(maxLength: 4000, nullable: true),
                    Comments = table.Column<string>(maxLength: 256, nullable: true),
                    HttpStatusCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AbpClaimTypes",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    name = table.Column<string>(maxLength: 256, nullable: false),
                    required = table.Column<bool>(nullable: false),
                    is_static = table.Column<bool>(nullable: false),
                    regex = table.Column<string>(maxLength: 512, nullable: true),
                    regex_description = table.Column<string>(maxLength: 128, nullable: true),
                    description = table.Column<string>(maxLength: 256, nullable: true),
                    value_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_claim_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnits",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    parent_id = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organization_unit", x => x.id);
                    table.ForeignKey(
                        name: "fk_abp_organization_units_abp_organization_units_organization_unit",
                        column: x => x.parent_id,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbpPermissionGrants",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    name = table.Column<string>(maxLength: 128, nullable: false),
                    provider_name = table.Column<string>(maxLength: 64, nullable: false),
                    provider_key = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission_grant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AbpRoles",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    name = table.Column<string>(maxLength: 256, nullable: false),
                    normalized_name = table.Column<string>(maxLength: 256, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AbpSettings",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 128, nullable: false),
                    value = table.Column<string>(maxLength: 2048, nullable: false),
                    provider_name = table.Column<string>(maxLength: 64, nullable: true),
                    provider_key = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_setting", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AbpTenants",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tenant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AbpUsers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true),
                    Surname = table.Column<string>(maxLength: 64, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
                    PasswordHash = table.Column<string>(maxLength: 256, nullable: true),
                    SecurityStamp = table.Column<string>(maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 16, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false, defaultValue: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false, defaultValue: false),
                    AccessFailedCount = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerApiResources",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    display_name = table.Column<string>(maxLength: 200, nullable: true),
                    description = table.Column<string>(maxLength: 1000, nullable: true),
                    enabled = table.Column<bool>(nullable: false),
                    properties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_resource", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClients",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    client_id = table.Column<string>(maxLength: 200, nullable: false),
                    client_name = table.Column<string>(maxLength: 200, nullable: true),
                    description = table.Column<string>(maxLength: 1000, nullable: true),
                    client_uri = table.Column<string>(maxLength: 2000, nullable: true),
                    logo_uri = table.Column<string>(maxLength: 2000, nullable: true),
                    enabled = table.Column<bool>(nullable: false),
                    protocol_type = table.Column<string>(maxLength: 200, nullable: false),
                    require_client_secret = table.Column<bool>(nullable: false),
                    require_consent = table.Column<bool>(nullable: false),
                    allow_remember_consent = table.Column<bool>(nullable: false),
                    always_include_user_claims_in_id_token = table.Column<bool>(nullable: false),
                    require_pkce = table.Column<bool>(nullable: false),
                    allow_plain_text_pkce = table.Column<bool>(nullable: false),
                    allow_access_tokens_via_browser = table.Column<bool>(nullable: false),
                    front_channel_logout_uri = table.Column<string>(maxLength: 2000, nullable: true),
                    front_channel_logout_session_required = table.Column<bool>(nullable: false),
                    back_channel_logout_uri = table.Column<string>(maxLength: 2000, nullable: true),
                    back_channel_logout_session_required = table.Column<bool>(nullable: false),
                    allow_offline_access = table.Column<bool>(nullable: false),
                    identity_token_lifetime = table.Column<int>(nullable: false),
                    access_token_lifetime = table.Column<int>(nullable: false),
                    authorization_code_lifetime = table.Column<int>(nullable: false),
                    consent_lifetime = table.Column<int>(nullable: true),
                    absolute_refresh_token_lifetime = table.Column<int>(nullable: false),
                    sliding_refresh_token_lifetime = table.Column<int>(nullable: false),
                    refresh_token_usage = table.Column<int>(nullable: false),
                    update_access_token_claims_on_refresh = table.Column<bool>(nullable: false),
                    refresh_token_expiration = table.Column<int>(nullable: false),
                    access_token_type = table.Column<int>(nullable: false),
                    enable_local_login = table.Column<bool>(nullable: false),
                    include_jwt_id = table.Column<bool>(nullable: false),
                    always_send_client_claims = table.Column<bool>(nullable: false),
                    client_claims_prefix = table.Column<string>(maxLength: 200, nullable: true),
                    pair_wise_subject_salt = table.Column<string>(maxLength: 200, nullable: true),
                    user_sso_lifetime = table.Column<int>(nullable: true),
                    user_code_type = table.Column<string>(maxLength: 100, nullable: true),
                    device_code_lifetime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerDeviceFlowCodes",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    device_code = table.Column<string>(maxLength: 200, nullable: false),
                    user_code = table.Column<string>(maxLength: 200, nullable: false),
                    subject_id = table.Column<string>(maxLength: 200, nullable: true),
                    client_id = table.Column<string>(maxLength: 200, nullable: false),
                    expiration = table.Column<DateTime>(nullable: false),
                    data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_flow_codes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerIdentityResources",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    display_name = table.Column<string>(maxLength: 200, nullable: true),
                    description = table.Column<string>(maxLength: 1000, nullable: true),
                    enabled = table.Column<bool>(nullable: false),
                    required = table.Column<bool>(nullable: false),
                    emphasize = table.Column<bool>(nullable: false),
                    show_in_discovery_document = table.Column<bool>(nullable: false),
                    properties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_resource", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerPersistedGrants",
                columns: table => new
                {
                    key = table.Column<string>(maxLength: 200, nullable: false),
                    id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    type = table.Column<string>(maxLength: 50, nullable: false),
                    subject_id = table.Column<string>(maxLength: 200, nullable: true),
                    client_id = table.Column<string>(maxLength: 200, nullable: false),
                    creation_time = table.Column<DateTime>(nullable: false),
                    expiration = table.Column<DateTime>(nullable: true),
                    data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_persisted_grants", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "AbpAuditLogActions",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(maxLength: 128, nullable: true),
                    Parameters = table.Column<string>(maxLength: 2000, nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_log_action", x => x.id);
                    table.ForeignKey(
                        name: "fk_audit_log_action_audit_log_audit_log_id",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityChanges",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    AuditLogId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    entity_tenant_id = table.Column<Guid>(nullable: true),
                    EntityId = table.Column<string>(maxLength: 128, nullable: false),
                    EntityTypeFullName = table.Column<string>(maxLength: 128, nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entity_change", x => x.id);
                    table.ForeignKey(
                        name: "fk_entity_change_audit_log_audit_log_id",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnitRoles",
                columns: table => new
                {
                    role_id = table.Column<Guid>(nullable: false),
                    organization_unit_id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abp_organization_unit_roles", x => new { x.organization_unit_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_organization_unit_role_organization_unit_organization_unit_id",
                        column: x => x.organization_unit_id,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abp_organization_unit_roles_abp_roles_identity_role_id",
                        column: x => x.role_id,
                        principalTable: "AbpRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpRoleClaims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    claim_type = table.Column<string>(maxLength: 256, nullable: false),
                    claim_value = table.Column<string>(maxLength: 1024, nullable: true),
                    role_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_role_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_identity_role_claim_identity_role_identity_role_id",
                        column: x => x.role_id,
                        principalTable: "AbpRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpTenantConnectionStrings",
                columns: table => new
                {
                    tenant_id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 64, nullable: false),
                    value = table.Column<string>(maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abp_tenant_connection_strings", x => new { x.tenant_id, x.name });
                    table.ForeignKey(
                        name: "fk_tenant_connection_string_tenant_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "AbpTenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserClaims",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    claim_type = table.Column<string>(maxLength: 256, nullable: false),
                    claim_value = table.Column<string>(maxLength: 1024, nullable: true),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_user_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_identity_user_claim_identity_user_identity_user_id",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserLogins",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    login_provider = table.Column<string>(maxLength: 64, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    provider_key = table.Column<string>(maxLength: 196, nullable: false),
                    provider_display_name = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abp_user_logins", x => new { x.user_id, x.login_provider });
                    table.ForeignKey(
                        name: "fk_identity_user_login_identity_user_identity_user_id",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserOrganizationUnits",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    organization_unit_id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abp_user_organization_units", x => new { x.organization_unit_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_abp_user_organization_units_abp_organization_units_organization_",
                        column: x => x.organization_unit_id,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_identity_user_organization_unit_identity_user_identity_user",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserRoles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abp_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_abp_user_roles_identity_role_identity_role_id",
                        column: x => x.role_id,
                        principalTable: "AbpRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_identity_user_role_identity_user_identity_user_id",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpUserTokens",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
                    login_provider = table.Column<string>(maxLength: 64, nullable: false),
                    name = table.Column<string>(maxLength: 128, nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abp_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_identity_user_token_identity_user_identity_user_id",
                        column: x => x.user_id,
                        principalTable: "AbpUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerApiClaims",
                columns: table => new
                {
                    type = table.Column<string>(maxLength: 200, nullable: false),
                    api_resource_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_api_claims", x => new { x.api_resource_id, x.type });
                    table.ForeignKey(
                        name: "fk_api_resource_claim_api_resource_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "IdentityServerApiResources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerApiScopes",
                columns: table => new
                {
                    api_resource_id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    display_name = table.Column<string>(maxLength: 200, nullable: true),
                    description = table.Column<string>(maxLength: 1000, nullable: true),
                    required = table.Column<bool>(nullable: false),
                    emphasize = table.Column<bool>(nullable: false),
                    show_in_discovery_document = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_api_scopes", x => new { x.api_resource_id, x.name });
                    table.ForeignKey(
                        name: "fk_api_scope_api_resource_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "IdentityServerApiResources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerApiSecrets",
                columns: table => new
                {
                    type = table.Column<string>(maxLength: 250, nullable: false),
                    value = table.Column<string>(maxLength: 4000, nullable: false),
                    api_resource_id = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(maxLength: 2000, nullable: true),
                    expiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_api_secrets", x => new { x.api_resource_id, x.type, x.value });
                    table.ForeignKey(
                        name: "fk_api_secret_api_resource_api_resource_id",
                        column: x => x.api_resource_id,
                        principalTable: "IdentityServerApiResources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientClaims",
                columns: table => new
                {
                    client_id = table.Column<Guid>(nullable: false),
                    type = table.Column<string>(maxLength: 250, nullable: false),
                    value = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_client_claims", x => new { x.client_id, x.type, x.value });
                    table.ForeignKey(
                        name: "fk_client_claim_client_client_id",
                        column: x => x.client_id,
                        principalTable: "IdentityServerClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientCorsOrigins",
                columns: table => new
                {
                    client_id = table.Column<Guid>(nullable: false),
                    origin = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_client_cors_origins", x => new { x.client_id, x.origin });
                    table.ForeignKey(
                        name: "fk_client_cors_origin_client_client_id",
                        column: x => x.client_id,
                        principalTable: "IdentityServerClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientGrantTypes",
                columns: table => new
                {
                    client_id = table.Column<Guid>(nullable: false),
                    grant_type = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_client_grant_types", x => new { x.client_id, x.grant_type });
                    table.ForeignKey(
                        name: "fk_client_grant_type_client_client_id",
                        column: x => x.client_id,
                        principalTable: "IdentityServerClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientIdPRestrictions",
                columns: table => new
                {
                    client_id = table.Column<Guid>(nullable: false),
                    provider = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_client_id_p_restrictions", x => new { x.client_id, x.provider });
                    table.ForeignKey(
                        name: "fk_client_id_p_restriction_client_client_id",
                        column: x => x.client_id,
                        principalTable: "IdentityServerClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientPostLogoutRedirectUris",
                columns: table => new
                {
                    client_id = table.Column<Guid>(nullable: false),
                    post_logout_redirect_uri = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_client_post_logout_redirect_uris", x => new { x.client_id, x.post_logout_redirect_uri });
                    table.ForeignKey(
                        name: "fk_client_post_logout_redirect_uri_client_client_id",
                        column: x => x.client_id,
                        principalTable: "IdentityServerClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientProperties",
                columns: table => new
                {
                    client_id = table.Column<Guid>(nullable: false),
                    key = table.Column<string>(maxLength: 250, nullable: false),
                    value = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_client_properties", x => new { x.client_id, x.key });
                    table.ForeignKey(
                        name: "fk_client_property_client_client_id",
                        column: x => x.client_id,
                        principalTable: "IdentityServerClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientRedirectUris",
                columns: table => new
                {
                    client_id = table.Column<Guid>(nullable: false),
                    redirect_uri = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_client_redirect_uris", x => new { x.client_id, x.redirect_uri });
                    table.ForeignKey(
                        name: "fk_client_redirect_uri_client_client_id",
                        column: x => x.client_id,
                        principalTable: "IdentityServerClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientScopes",
                columns: table => new
                {
                    client_id = table.Column<Guid>(nullable: false),
                    scope = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_client_scopes", x => new { x.client_id, x.scope });
                    table.ForeignKey(
                        name: "fk_client_scope_client_client_id",
                        column: x => x.client_id,
                        principalTable: "IdentityServerClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerClientSecrets",
                columns: table => new
                {
                    type = table.Column<string>(maxLength: 250, nullable: false),
                    value = table.Column<string>(maxLength: 4000, nullable: false),
                    client_id = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(maxLength: 2000, nullable: true),
                    expiration = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_client_secrets", x => new { x.client_id, x.type, x.value });
                    table.ForeignKey(
                        name: "fk_client_secret_client_client_id",
                        column: x => x.client_id,
                        principalTable: "IdentityServerClients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerIdentityClaims",
                columns: table => new
                {
                    type = table.Column<string>(maxLength: 200, nullable: false),
                    identity_resource_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_identity_claims", x => new { x.identity_resource_id, x.type });
                    table.ForeignKey(
                        name: "fk_identity_claim_identity_resource_identity_resource_id",
                        column: x => x.identity_resource_id,
                        principalTable: "IdentityServerIdentityResources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpEntityPropertyChanges",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: true),
                    entity_change_id = table.Column<Guid>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 128, nullable: false),
                    PropertyTypeFullName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entity_property_change", x => x.id);
                    table.ForeignKey(
                        name: "fk_entity_property_change_entity_change_entity_change_id",
                        column: x => x.entity_change_id,
                        principalTable: "AbpEntityChanges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityServerApiScopeClaims",
                columns: table => new
                {
                    type = table.Column<string>(maxLength: 200, nullable: false),
                    api_resource_id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_identity_server_api_scope_claims", x => new { x.api_resource_id, x.name, x.type });
                    table.ForeignKey(
                        name: "fk_api_scope_claim_identity_server_api_scopes_api_scope_api_resou",
                        columns: x => new { x.api_resource_id, x.name },
                        principalTable: "IdentityServerApiScopes",
                        principalColumns: new[] { "api_resource_id", "name" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_audit_log_action_audit_log_id",
                table: "AbpAuditLogActions",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "ix_abp_audit_log_actions_tenant_id_service_name_method_name_executio",
                table: "AbpAuditLogActions",
                columns: new[] { "TenantId", "ServiceName", "MethodName", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "ix_abp_audit_logs_tenant_id_execution_time",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "execution_time" });

            migrationBuilder.CreateIndex(
                name: "ix_abp_audit_logs_tenant_id_user_id_execution_time",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "UserId", "execution_time" });

            migrationBuilder.CreateIndex(
                name: "ix_entity_change_audit_log_id",
                table: "AbpEntityChanges",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "ix_abp_entity_changes_tenant_id_entity_type_full_name_entity_id",
                table: "AbpEntityChanges",
                columns: new[] { "TenantId", "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "ix_entity_property_change_entity_change_id",
                table: "AbpEntityPropertyChanges",
                column: "entity_change_id");

            migrationBuilder.CreateIndex(
                name: "ix_abp_organization_unit_roles_role_id_organization_unit_id",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "role_id", "organization_unit_id" });

            migrationBuilder.CreateIndex(
                name: "ix_abp_organization_units_code",
                table: "AbpOrganizationUnits",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "ix_abp_organization_units_parent_id",
                table: "AbpOrganizationUnits",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "ix_abp_permission_grants_name_provider_name_provider_key",
                table: "AbpPermissionGrants",
                columns: new[] { "name", "provider_name", "provider_key" });

            migrationBuilder.CreateIndex(
                name: "ix_identity_role_claim_role_id",
                table: "AbpRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_abp_roles_normalized_name",
                table: "AbpRoles",
                column: "normalized_name");

            migrationBuilder.CreateIndex(
                name: "ix_abp_settings_name_provider_name_provider_key",
                table: "AbpSettings",
                columns: new[] { "name", "provider_name", "provider_key" });

            migrationBuilder.CreateIndex(
                name: "ix_abp_tenants_name",
                table: "AbpTenants",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_identity_user_claim_user_id",
                table: "AbpUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_abp_user_logins_login_provider_provider_key",
                table: "AbpUserLogins",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.CreateIndex(
                name: "ix_abp_user_organization_units_user_id_organization_unit_id",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "user_id", "organization_unit_id" });

            migrationBuilder.CreateIndex(
                name: "ix_abp_user_roles_role_id_user_id",
                table: "AbpUserRoles",
                columns: new[] { "role_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "ix_abp_users_email",
                table: "AbpUsers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "ix_abp_users_normalized_email",
                table: "AbpUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "ix_abp_users_normalized_user_name",
                table: "AbpUsers",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "ix_abp_users_user_name",
                table: "AbpUsers",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "ix_identity_server_clients_client_id",
                table: "IdentityServerClients",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_identity_server_device_flow_codes_device_code",
                table: "IdentityServerDeviceFlowCodes",
                column: "device_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_server_device_flow_codes_expiration",
                table: "IdentityServerDeviceFlowCodes",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "ix_identity_server_device_flow_codes_user_code",
                table: "IdentityServerDeviceFlowCodes",
                column: "user_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_identity_server_persisted_grants_expiration",
                table: "IdentityServerPersistedGrants",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "ix_identity_server_persisted_grants_subject_id_client_id_type",
                table: "IdentityServerPersistedGrants",
                columns: new[] { "subject_id", "client_id", "type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuditLogActions");

            migrationBuilder.DropTable(
                name: "AbpClaimTypes");

            migrationBuilder.DropTable(
                name: "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnitRoles");

            migrationBuilder.DropTable(
                name: "AbpPermissionGrants");

            migrationBuilder.DropTable(
                name: "AbpRoleClaims");

            migrationBuilder.DropTable(
                name: "AbpSettings");

            migrationBuilder.DropTable(
                name: "AbpTenantConnectionStrings");

            migrationBuilder.DropTable(
                name: "AbpUserClaims");

            migrationBuilder.DropTable(
                name: "AbpUserLogins");

            migrationBuilder.DropTable(
                name: "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpUserRoles");

            migrationBuilder.DropTable(
                name: "AbpUserTokens");

            migrationBuilder.DropTable(
                name: "IdentityServerApiClaims");

            migrationBuilder.DropTable(
                name: "IdentityServerApiScopeClaims");

            migrationBuilder.DropTable(
                name: "IdentityServerApiSecrets");

            migrationBuilder.DropTable(
                name: "IdentityServerClientClaims");

            migrationBuilder.DropTable(
                name: "IdentityServerClientCorsOrigins");

            migrationBuilder.DropTable(
                name: "IdentityServerClientGrantTypes");

            migrationBuilder.DropTable(
                name: "IdentityServerClientIdPRestrictions");

            migrationBuilder.DropTable(
                name: "IdentityServerClientPostLogoutRedirectUris");

            migrationBuilder.DropTable(
                name: "IdentityServerClientProperties");

            migrationBuilder.DropTable(
                name: "IdentityServerClientRedirectUris");

            migrationBuilder.DropTable(
                name: "IdentityServerClientScopes");

            migrationBuilder.DropTable(
                name: "IdentityServerClientSecrets");

            migrationBuilder.DropTable(
                name: "IdentityServerDeviceFlowCodes");

            migrationBuilder.DropTable(
                name: "IdentityServerIdentityClaims");

            migrationBuilder.DropTable(
                name: "IdentityServerPersistedGrants");

            migrationBuilder.DropTable(
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "AbpTenants");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpRoles");

            migrationBuilder.DropTable(
                name: "AbpUsers");

            migrationBuilder.DropTable(
                name: "IdentityServerApiScopes");

            migrationBuilder.DropTable(
                name: "IdentityServerClients");

            migrationBuilder.DropTable(
                name: "IdentityServerIdentityResources");

            migrationBuilder.DropTable(
                name: "AbpAuditLogs");

            migrationBuilder.DropTable(
                name: "IdentityServerApiResources");
        }
    }
}
