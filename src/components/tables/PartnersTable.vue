<template>
  <div>
    <q-table
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Партнеры</h6>
          <q-btn @click="addPartner = true" v-if="!isCreation" size="sm" color="secondary" :icon="icons.mdiPlus" label="партнера" />
          <q-btn @click="createPartner = true" v-if="isCreation" size="sm" color="secondary" :icon="icons.mdiPencil" label="партнера" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit
              v-model="props.row.name"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.name" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="counterparty" :props="props">
            {{ props.row.counterparty }}
          </q-td>

          <q-td key="relationship" :props="props">
            {{ props.row.relationship }}
          </q-td>

          <q-td key="address" :props="props">
            {{ props.row.address }}
          </q-td>

          <q-td key="manager" :props="props">
            {{ props.row.manager }}
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.partnerId)" :loading="loading" />
            <q-btn class="q-ml-sm" color="secondary" size="sm" label="Просмотр" @click="getPartner(props.row.partnerId)" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <q-dialog v-model="addPartner" v-if="!isCreation" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Добавление партнера.</span>
        </q-card-section>

        <AddBankAccountPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

    <q-dialog v-model="createPartner" v-if="isCreation" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Создание партнера.</span>
        </q-card-section>

        <AddBankAccountPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script>
import AddBankAccountPopup from 'components/addingElements/AddBankAccountPopup'
import icons from 'src/mixins/icons'
export default {
  name: 'PartnersTable',
  components: {
    AddBankAccountPopup
  },
  mixins: [icons],
  props: {
    data: {
      type: Array,
      default: () => []
    },
    isCreation: {
      type: Boolean,
      default: () => true
    }
  },
  methods: {
    saveChanges (partnerId) {
    },
    getPartner (partnerId) {
      this.$router.push('/partner/' + partnerId + '?tab=partnerInfo')
    }
  },
  data: () => {
    return {
      loading: false,
      addPartner: false,
      createPartner: false,
      columns: [
        { name: 'name', label: 'Название', align: 'left', field: 'name' },
        { name: 'counterparty', label: 'Контрагент', field: 'counterparty' },
        { name: 'relationship', label: 'Отношения', field: 'relationship' },
        { name: 'address', label: 'Адресс', field: 'address' },
        { name: 'manager', label: 'Ответственный менеджер', field: 'manager' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
