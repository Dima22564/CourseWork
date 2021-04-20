<template>
  <q-page padding>
    <div>
      <q-item
        clickable
        tag="a"
        to="/new-partner/create"
        exact
      >
        <q-item-section>
          <q-item-label>Добавить партнера</q-item-label>
        </q-item-section>
      </q-item>

      <q-item
        clickable
        tag="a"
        to="/partner/all"
        exact
      >
        <q-item-section>
          <q-item-label>Все партнеры</q-item-label>
        </q-item-section>
      </q-item>

      <q-item
        clickable
        tag="a"
        to="/business-proposal/all"
        exact
      >
        <q-item-section>
          <q-item-label>Коммерческие предложения</q-item-label>
        </q-item-section>
      </q-item>

      <q-item
        clickable
        tag="a"
        to="/standart-agreements/all"
        exact
      >
        <q-item-section>
          <q-item-label>Соглашения с партнерами</q-item-label>
        </q-item-section>
      </q-item>
    </div>

  </q-page>
</template>

<script>
export default {
  name: 'IndexPagePartner'
}
</script>
