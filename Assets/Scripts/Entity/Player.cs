using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    [SerializeField] private AudioClip _elementChangeSound;
    [SerializeField] private PlayerElementData _redElementData, _greenElementData, _blueElementData, _darkElementData;

    [SerializeField] private float _speed;
    [SerializeField] private float _aimDistance;
    [SerializeField] private Projectile _projectilePrefab;

    [SerializeField] private float _shootDistance;

    public Transform Boss;
    [SerializeField] private bool _isBossMoving;
    [SerializeField] private Light _orbLight;

    public ParticleSystem DamageParticle;

    [SerializeField] private MeshRenderer _renderer;

    public PlayerElementData CurrentElement;

    [HideInInspector] public bool IsInvulnerable = false;

    public float AttackCooldown = 0.5f;
    public float SkillCooldown = 10f;

    private float _attackTimer = 0f;
    private float _fireSkillTimer = 0f, _waterSkillTimer = 0f, _earthSkillTimer = 0f;

    protected override void Awake()
    {
        base.Awake();
        ChangeElement(CurrentElement, true);
    }

    private void Update()
    {
        MoveUpdate();
        ShootUpdate();
        ElementChangeUpdate();
        SkillUpdate();
    }

    public static bool IsDominentTo(ElementType elementType, ElementType target)
    {
        if (elementType == ElementType.Fire && target == ElementType.Earth) return true;
        if (elementType == ElementType.Water && target == ElementType.Fire) return true;
        if (elementType == ElementType.Earth && target == ElementType.Water) return true;
        if (elementType == ElementType.Light && target == ElementType.Dark) return true;
        return false;
    }

    private void ElementChangeUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            ChangeElement(_darkElementData);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            ChangeElement(_blueElementData);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            ChangeElement(_greenElementData);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            ChangeElement(_redElementData);
        }
    }

    private void SkillUpdate()
    {
        if (_fireSkillTimer > 0f) _fireSkillTimer -= Time.deltaTime;
        if (_earthSkillTimer > 0f) _earthSkillTimer -= Time.deltaTime;
        if (_waterSkillTimer > 0f) _waterSkillTimer -= Time.deltaTime;
    }

    public void ChangeElement(PlayerElementData data, bool slient = false)
    {
        _renderer.material = data.Material;
        _orbLight.color = data.LightColor;
        if(data.SpawnParticle != null && !slient) 
            ParticleManager.SpawnParticle(data.SpawnParticle, transform.position, transform);
        CurrentElement = data;
        GameManager.Instance.SoundManager.PlaySFX(_elementChangeSound, transform);

        switch(data.ElementType)
        {
            case ElementType.Fire:
                {
                    if(_fireSkillTimer <= 0f)
                        StartCoroutine(FireSkill());
                }
                break;
            case ElementType.Water:
                {
                    if (_waterSkillTimer <= 0f)
                        StartCoroutine(WaterSkill());

                }
                break;
            case ElementType.Earth:
                {
                    if (_earthSkillTimer <= 0f)
                        StartCoroutine(EarthSkill());

                }
                break;
        }
    }

    private IEnumerator FireSkill()
    {
        AttackCooldown /= 2f;
        yield return new WaitForSeconds(2f);
        AttackCooldown *= 2f;
    }

    private IEnumerator WaterSkill()
    {
        IsInvulnerable = true;
        yield return new WaitForSeconds(2f);
        IsInvulnerable = false;
    }

    private IEnumerator EarthSkill()
    {
        if (hp < MaxHP) hp++;

        yield return null;
    }

    public override void Damage(int damage)
    {
        if (!IsInvulnerable)
        {
            base.Damage(damage);
            GameManager.Instance.DamageScreen.ShowDamage();
        }
        ParticleManager.SpawnParticle(DamageParticle, transform.position);
    }

    private void ShootUpdate()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var dir = ray.direction;
        transform.forward = dir;

        if (_attackTimer > 0) _attackTimer -= Time.deltaTime;

        if (Input.GetMouseButton(0) && _attackTimer <= 0f)
        {
            _attackTimer = AttackCooldown;
            if (CurrentElement.ProjectParticle != null)
                ParticleManager.SpawnParticle(CurrentElement.ProjectParticle, transform.position, transform);
            var projectile = Instantiate(CurrentElement.Projectile, transform.position + transform.forward * _shootDistance, Quaternion.identity);
            projectile.transform.forward = dir;
            projectile.CameraOffset = projectile.transform.position - Camera.main.transform.position;
            projectile.IsEnemyProjectile = false;
            GameManager.Instance.SoundManager.PlaySFX(CurrentElement.ShootSound, transform);
        }
    }

    protected override void OnDeath()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void OnClear()
    {
        PlayerPrefs.SetInt("Score", GameManager.Instance.scoreManager.score);
        var NextStage = PlayerPrefs.GetInt("RecentStage", 0) + 1;
        PlayerPrefs.SetInt("RecentStage", NextStage);
        var nextStageData = StageManager.CurrentStageData;
        if(nextStageData != null)
        {
            SceneManager.LoadScene("StoryScene");
        }
        else
        {
            SceneManager.LoadScene("EndingScene");
        }
    }

    private void MoveUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        if (_isBossMoving)
        {
            var bossDir = (transform.position - Boss.position);
            bossDir.y = 0;
            var distance = bossDir.magnitude;
            var angle = Mathf.Atan2(bossDir.z, bossDir.x);
            // 2 * pi * r = 원주
            // 각도 * r = 움직이는 속도
            // 속도 / r = 각속도
            angle += xAxis * Time.deltaTime * _speed / distance;
            transform.position = new Vector3(Boss.position.x, transform.position.y, Boss.position.z) 
                + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)).normalized * distance;
        }
        else
        {
            transform.position += _speed * xAxis * Time.deltaTime * Vector3.right;
        }
    }
}