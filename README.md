# GP_teamproject
게임프로그래밍언어 팀플, 개발된 사항들 적어놓는 곳

전반적인 개임 토대 완성, 플레이 가능한 상태

적의 스탯은 EnemyManager 스크립트에, 플레이어는 PlayerStatus 스크립트에 정의되어 있고, 
관련 기능의 처리는 둘 다 끝에 Manager라 이름붙인 스크립트에서 처리할 예정

개발이 필요한 사항들

1. 각종 업그레이드 요소들
2. 적 티어 시스템과 그에따른 배경 변화
3. 플레이어 1티어 케릭터의 애니메이션
4. 각 티어별 투사체
5. 게임 시작시 등장하는 메인 매뉴 화면, 게임오버 씬에 쓰일 화면
6. 각종 버튼들 (티어 상승 버튼, 업그레이드 요소 버튼)
7. 기타 필요한 디자인
   


업그레이드 요소 만드는 법 (상세한 사항은 김정훈<<에게 카톡 주시면 설명해드립니다)
1. 업그레이드의 현재 레벨 및 최대레벨, 이 업그레이드의 레벨을 올리기 위한 버튼, 이 업그레이드에서 필요로하는 프리펩 등... 과 같은 데이터는 스크립터블 오브젝트 중 UpdateData에 작성하시면 됩니다
  해당 스크립터블 오브젝트는 프로젝트 창에서 우클릭, create 메뉴를 통해 생성 가능하며 upgrade폴더에 담아주시면 감사하겠습니다.
2.  해당 업그레이드의 레벨을 올리기 위한 버튼(파워업 아이템 획득시 등장할 버튼을 의미)은 upgrade폴더의 버튼들을 담는 폴더에 있는 프리펩들을 복사하여 수정해 사용하시면 됩니다
    ***생성한 버튼 프리펩은 전단계에서 생성한 해당 업그레이드의 스크립터블 오브젝트에 등록해주셔야 합니다. (안그러면 게임에서 등장을 안합니다)***
3. 해당 업그레이드가 선택되었을 때의 작동은 다른 업그레이드 버튼들에 달린 BtnEvent 스크립트를 참조하여 작성하시면 됩니다
    기존 스크립트를 복사한 뒤, UpgradeEvent()함수 부분에 업그레이드 버튼을 눌렀을 때 작동할 내용을 수정하여 작성하시면 됩니다. ***그 외의 부분은 건들었다간 작동을 안하거나 업그레이드가 끝나도 계속 화면에 남아있게 될 수 있습니다.***
   ***upgradeEvent()함수 마지막에 반드시 Destroy(this.GameObject)가 들어가야 합니다. 그렇지 않으면 선택된 버튼이 사라지지 않아 다음 파워업 아이템을 먹으면 해당 버튼이 남아있는걸 보게 됩니다*** 
